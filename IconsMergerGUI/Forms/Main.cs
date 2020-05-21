#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using IconsMergerGUI.Controls;
using IconsMergerGUI.Forms;
using IconsMergerGUI.Models;
using IconsMergerGUI.Utils;
using LiteDB;
using Svg;
#endregion

namespace IconsMergerGUI.Forms
{
    public partial class Main : Form
    {
        #region Members

        private string databaseName = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), "..", "..", "..", "Database", "icons.db" );

        private LiteDatabase db;

        private ILiteCollection<Pack> packCollection;

        private ILiteCollection<Icon> iconCollection;

        private ILiteCollection<MappedIcon> mappedIconCollection;

        #endregion

        #region Constructors

        public Main()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Form

        private void Main_Load( object sender, EventArgs e )
        {
            try
            {
                db = new LiteDatabase( databaseName );

                packCollection = db.GetCollection<Pack>( Constants.PackCollection );
                iconCollection = db.GetCollection<Icon>( Constants.IconCollection );
                mappedIconCollection = db.GetCollection<MappedIcon>( Constants.MappedIconCollection );

                var packList = packCollection.FindAll().OrderBy( x => x.Name ).ToList();

                foreach ( var pack in packList )
                {
                    AddIconsGrid( pack.Name );
                }

                LoadAll();
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void Form1_FormClosed( object sender, FormClosedEventArgs e )
        {
            db?.Dispose();
        }

        #endregion

        #region Commands

        private void btnMap_Click( object sender, EventArgs e )
        {
            try
            {
                var icons = GetGridControls()
                    .Where( x => x.SelectedIcon != null )
                    .Select( x => x.SelectedIcon ).ToList();

                var iconName = icons.First().NormalizedName;

                var suggestedNewIconName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase( iconName.Replace( "-", " " ) ).Replace( " ", string.Empty );

                using ( var form = new MapName( suggestedNewIconName, icons.Select( x => ImageTools.ByteArrayToImage( x.Image ) ).ToList() ) )
                {
                    if ( form.ShowDialog() == DialogResult.OK )
                    {
                        var newIconName = form.NewIconName;

                        if ( mappedIconCollection.Exists( x => x.Name == newIconName ) )
                        {
                            MessageBox.Show( "Name already exists!" );
                            return;
                        }

                        var mappedIcon = new MappedIcon
                        {
                            Name = newIconName,
                            NormalizedMappedName = iconName,
                            Icons = new List<Icon>( icons ),
                        };

                        mappedIconCollection.Insert( mappedIcon );

                        //foreach ( var icon in icons )
                        //{
                        //    iconCollection.Delete( icon.Id );
                        //}

                        LoadAll();
                    }
                }
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void btnAutoMap_Click( object sender, EventArgs e )
        {
            try
            {
                // find all the duplicated by name
                var duplicates = ( from i in iconCollection.FindAll()
                                   group i by i.NormalizedName into g
                                   where g.Count() > 1
                                   select g.Key ).ToList();

                foreach ( var duplicate in duplicates )
                {
                    var icons = iconCollection.Find( x => x.NormalizedName == duplicate ).ToList();

                    var name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase( duplicate.Replace( "-", " " ) ).Replace( " ", string.Empty );

                    if ( mappedIconCollection.Exists( x => x.Name == name ) )
                        continue;

                    var mappedIcon = new MappedIcon
                    {
                        Name = name,
                        NormalizedMappedName = duplicate,
                        Icons = new List<Icon>( icons ),
                    };

                    mappedIconCollection.Insert( mappedIcon );

                    //foreach ( var icon in icons )
                    //{
                    //    iconCollection.Delete( icon.Id );
                    //}
                }

                LoadAll();
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void btnAutoMapExisting_Click( object sender, EventArgs e )
        {
            try
            {
                using ( var form = new PackSelect( packCollection.FindAll().Select( x => x.Name ).ToArray() ) )
                {
                    if ( form.ShowDialog() == DialogResult.OK && form.PackName != null )
                    {
                        var icons = iconCollection.Find( x => x.Pack == form.PackName ).ToList();

                        foreach ( var icon in icons )
                        {
                            var mappedIcon = mappedIconCollection.FindOne( x => x.NormalizedMappedName == icon.NormalizedName );

                            if ( mappedIcon == null )
                                continue;

                            if ( mappedIcon.Icons.Any( x => x.Pack == icon.Pack ) )
                                continue;

                            mappedIcon.Icons.Add( icon );

                            mappedIconCollection.Update( mappedIcon );
                        }

                        LoadAll();
                    }
                }
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void btnIconsImport_Click( object sender, EventArgs e )
        {
            try
            {
                using ( var dialog = new PackImport() )
                {
                    if ( dialog.ShowDialog() == DialogResult.OK )
                    {
                        var packName = dialog.PackName;

                        var loader = IconLoaderFactory.Create( db, packName );

                        if ( loader == null )
                            throw new ArgumentNullException( "Loader not found!" );

                        loader.Load( dialog.SelectedPath );

                        var pack = packCollection.FindOne( x => x.Name == packName );

                        if ( pack == null )
                        {
                            pack = new Pack { Name = packName };

                            packCollection.Insert( pack );
                        }

                        AddIconsGrid( pack.Name )
                            .LoadAll();

                        MessageBox.Show( "Done" );
                    }
                }
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void btnIconsExport_Click( object sender, EventArgs e )
        {
            try
            {
                using ( var dialog = new FolderBrowserDialog() )
                {
                    if ( dialog.ShowDialog() == DialogResult.OK )
                    {
                        var selectedPath = dialog.SelectedPath;

                        var packs = packCollection.FindAll().OrderBy( x => x.Name ).ToList();
                        var mappedIcons = mappedIconCollection.FindAll().OrderBy( x => x.Name ).ToList();


                        var sbEnums = new StringBuilder();
                        var sbMaterialDict = new StringBuilder();
                        var sbFontAwesomeDict = new StringBuilder();

                        sbEnums.AppendLine( "public enum IconName" );
                        sbEnums.AppendLine( "{" );

                        sbMaterialDict.AppendLine( "private static Dictionary<IconName, string> names = new Dictionary<IconName, string>" );
                        sbMaterialDict.AppendLine( "{" );

                        sbFontAwesomeDict.AppendLine( "private static Dictionary<IconName, string> names = new Dictionary<IconName, string>" );
                        sbFontAwesomeDict.AppendLine( "{" );

                        foreach ( var mappedIcon in mappedIcons )
                        {
                            sbEnums.AppendLine( $"    {mappedIcon.Name}," );
                        }

                        var fontAwesomeIcons = ( from m in mappedIcons from i in m.Icons where i.Pack == Constants.FontAwesome orderby m.Name ascending select new { EnumName = m.Name, IconName = i.Name } ).ToList();
                        var materialIcons = ( from m in mappedIcons from i in m.Icons where i.Pack == Constants.Material orderby m.Name ascending select new { EnumName = m.Name, IconName = i.Name } ).ToList();

                        foreach ( var icon in fontAwesomeIcons )
                        {
                            sbFontAwesomeDict.AppendLine( $"    {{ IconName.{icon.EnumName}, \"fa-{icon.IconName}\" }}," );
                        }

                        foreach ( var icon in materialIcons )
                        {
                            sbMaterialDict.AppendLine( $"    {{ IconName.{icon.EnumName}, \"{icon.IconName}\" }}," );
                        }

                        sbEnums.AppendLine( "}" );
                        sbMaterialDict.AppendLine( "};" );
                        sbFontAwesomeDict.AppendLine( "};" );

                        File.WriteAllText( Path.Combine( selectedPath, "enums.cs" ), sbEnums.ToString() );
                        File.WriteAllText( Path.Combine( selectedPath, "material.cs" ), sbMaterialDict.ToString() );
                        File.WriteAllText( Path.Combine( selectedPath, "fontawesome.cs" ), sbFontAwesomeDict.ToString() );
                    }
                }
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        #endregion

        #region Icons

        private void IconsGrid_SelectionChanged( object sender, EventArgs e )
        {
            btnMap.Enabled = GetGridControls().Count( x => x.SelectedIcon != null ) >= 2;
        }

        #endregion

        #region MappedIcons

        private void dgMappedIcons_CellValidating( object sender, DataGridViewCellValidatingEventArgs e )
        {
            if ( e.RowIndex == -1 || e.ColumnIndex == -1 )
                return;

            try
            {
                var newName = e.FormattedValue?.ToString();

                if ( dgMappedIcons.EditingControl != null && string.IsNullOrEmpty( newName ) )
                {
                    e.Cancel = true;

                    throw new ArgumentException( "Name cannot be empty!" );
                }

                var id = new ObjectId( dgMappedIcons.Rows[e.RowIndex].Cells[0].Value.ToString() );

                if ( mappedIconCollection.Exists( x => x.Name == newName && x.Id != id ) )
                {
                    e.Cancel = true;

                    throw new DuplicateNameException( "Name already exists!" );
                }
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void dgMappedIcons_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            if ( e.RowIndex == -1 || e.ColumnIndex == -1 )
                return;

            try
            {
                var newName = dgMappedIcons.Rows[e.RowIndex].Cells[1].Value?.ToString();

                var id = new ObjectId( dgMappedIcons.Rows[e.RowIndex].Cells[0].Value.ToString() );

                var mappedIcon = mappedIconCollection.FindById( id );

                mappedIcon.Name = newName;

                mappedIconCollection.Update( mappedIcon );
            }
            catch ( Exception exc )
            {
                MessageBox.Show( exc.Message );
            }
        }

        private void dgMappedIcons_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e )
        {
            if ( MessageBox.Show( "Delete", "Delete mapped icon?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
            {
                var mappedIcon = mappedIconCollection.FindById( new ObjectId( e.Row.Cells[0].Value.ToString() ) );

                //foreach ( var icon in mappedIcon.Icons )
                //{
                //    iconCollection.Insert( icon );
                //}

                mappedIconCollection.Delete( mappedIcon.Id );

                LoadAll();
            }
            else
                e.Cancel = true;
        }

        private void dgMappedIcons_DragOver( object sender, DragEventArgs e )
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgMappedIcons_DragDrop( object sender, DragEventArgs e )
        {
            System.Drawing.Point clientPoint = dgMappedIcons.PointToClient( new System.Drawing.Point( e.X, e.Y ) );

            // If the drag operation was a copy then add the row to the other control.
            if ( e.Effect == DragDropEffects.Copy )
            {
                var hitTest = dgMappedIcons.HitTest( clientPoint.X, clientPoint.Y );

                var droppedIcon = e.Data.GetData( typeof( Icon ) ) as Icon;

                if ( hitTest.RowIndex != -1 && droppedIcon != null )
                {
                    var mappedIcon = mappedIconCollection.FindById( new ObjectId( dgMappedIcons.Rows[hitTest.RowIndex].Cells[0].Value.ToString() ) );

                    if ( mappedIcon != null )
                    {
                        var replaceIcon = mappedIcon.Icons.FirstOrDefault( x => x.Pack == droppedIcon.Pack );

                        if ( replaceIcon != null )
                        {
                            mappedIcon.Icons.Remove( replaceIcon );
                        }

                        mappedIcon.Icons.Add( droppedIcon );

                        mappedIconCollection.Update( mappedIcon );

                        dgMappedIcons.Rows[hitTest.RowIndex].Cells[$"{droppedIcon.Pack}Name"].Value = droppedIcon.Name;
                        dgMappedIcons.Rows[hitTest.RowIndex].Cells[$"{droppedIcon.Pack}Image"].Value = droppedIcon.Image;

                        dgMappedIcons.Update();
                    }
                }
            }
        }

        private void dgMappedIcons_DataSourceChanged( object sender, EventArgs e )
        {
            if ( dgMappedIcons.DataSource != null && dgMappedIcons.DataSource is DataTable dt )
            {
                lblMappedIcons.Text = $"Mapped icons: {dt.Rows.Count}";
            }
        }

        #endregion

        #endregion

        #region Methods

        private IconsGridControl AddIconsGrid( string packName )
        {
            var iconsGrid = GetGridControls().FirstOrDefault( x => x.PackName == packName );

            if ( iconsGrid == null )
            {
                iconsGrid = new IconsGridControl( db, packName )
                {
                    //Dock = DockStyle.Left,
                    Left = GetGridControls().LastOrDefault()?.Right ?? 0,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
                };

                iconsGrid.SelectionChanged += IconsGrid_SelectionChanged;

                pnlPacks.Controls.Add( iconsGrid );

                //pnlPacks.Controls.Add( new Splitter() );

            }

            return iconsGrid;
        }

        private void LoadAll()
        {
            LoadIcons();
            LoadMappedIcons();
        }

        private void LoadIcons()
        {
            foreach ( var gridControl in GetGridControls() )
            {
                gridControl.LoadAll();
            }
        }

        private void LoadMappedIcons()
        {
            dgMappedIcons.Columns.Clear();
            dgMappedIcons.DataSource = null;

            var dt = new DataTable();

            // create "fixed" columns
            dt.Columns.Add( "Id" );
            dt.Columns.Add( "Name" );

            var packs = packCollection.FindAll().OrderBy( x => x.Name ).ToList();

            foreach ( var pack in packs )
            {
                // create custom columns
                dt.Columns.Add( $"{pack.Name}Name" );
                dt.Columns.Add( $"{pack.Name}Image", typeof( byte[] ) );
            }

            var mappedIcons = mappedIconCollection.FindAll().ToList();

            foreach ( var mappedIcon in mappedIcons )
            {
                var row = new List<object>( new object[] { mappedIcon.Id, mappedIcon.Name } );

                // we select by pack name so that we keep the same ordering as generated columns
                foreach ( var pack in packs )
                {
                    var icon = mappedIcon.Icons.FirstOrDefault( x => x.Pack == pack.Name );

                    row.Add( icon?.Name );
                    row.Add( icon?.Image );
                }

                dt.Rows.Add( row.ToArray() );
            }

            dgMappedIcons.DataSource = dt;

            // Only Name column is allowed to be edited
            foreach ( DataGridViewColumn column in dgMappedIcons.Columns )
            {
                column.ReadOnly = column.Name != "Name";
            }

            dgMappedIcons.Columns[0].Visible = false;
        }

        private IEnumerable<IconsGridControl> GetGridControls()
        {
            foreach ( var control in pnlPacks.Controls )
            {
                if ( control is IconsGridControl gridControl )
                    yield return gridControl;
            }
        }

        #endregion

        #region Properties

        #endregion
    }
}
