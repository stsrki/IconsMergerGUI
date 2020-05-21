#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IconsMergerGUI.Models;
using LiteDB;
#endregion

namespace IconsMergerGUI.Controls
{
    public partial class IconsGridControl : UserControl
    {
        #region Members

        private ILiteCollection<Icon> collection;

        public event EventHandler<EventArgs> SelectionChanged;

        private System.Drawing.Rectangle dragBoxFromMouseDown;

        private object valueFromMouseDown;

        #endregion

        #region Constructors

        public IconsGridControl()
        {
            InitializeComponent();
        }

        public IconsGridControl( LiteDatabase db, string packName )
            : this()
        {
            dgIcons.AutoGenerateColumns = false;

            lblPackName.Text = PackName = packName;

            collection = db.GetCollection<Icon>( Constants.IconCollection );
        }

        #endregion

        #region Events

        private void txtSearch_TextChanged( object sender, EventArgs e )
        {
            LoadAll();
        }

        private void dgIcons_SelectionChanged( object sender, EventArgs e )
        {
            SelectedIcon = dgIcons.SelectedRows.Count > 0
                ? collection.FindById( dgIcons.SelectedRows[0].Cells[0].Value as ObjectId )
                : null;

            SelectionChanged?.Invoke( this, EventArgs.Empty );
        }

        private void dgIcons_MouseDown( object sender, MouseEventArgs e )
        {
            var hittestInfo = dgIcons.HitTest( e.X, e.Y );

            if ( hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1 )
            {
                var id = new ObjectId( dgIcons.Rows[hittestInfo.RowIndex].Cells[0].Value.ToString() );

                valueFromMouseDown = collection.FindById( id );

                if ( valueFromMouseDown != null )
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    System.Drawing.Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new System.Drawing.Rectangle( new System.Drawing.Point( e.X - ( dragSize.Width / 2 ), e.Y - ( dragSize.Height / 2 ) ), dragSize );
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = System.Drawing.Rectangle.Empty;
        }

        private void dgIcons_MouseMove( object sender, MouseEventArgs e )
        {
            if ( ( e.Button & MouseButtons.Left ) == MouseButtons.Left )
            {
                // If the mouse moves outside the rectangle, start the drag.
                if ( dragBoxFromMouseDown != System.Drawing.Rectangle.Empty && !dragBoxFromMouseDown.Contains( e.X, e.Y ) )
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgIcons.DoDragDrop( valueFromMouseDown, DragDropEffects.Copy );
                }
            }
        }

        #endregion

        #region Methods

        public void LoadAll()
        {
            var search = txtSearch.Text;

            var result = !string.IsNullOrEmpty( search )
                ? collection.Find( x => x.Pack == PackName && x.Name.Contains( txtSearch.Text ) ).OrderBy( x => x.Name ).ToList()
                : collection.Find( x => x.Pack == PackName ).OrderBy( x => x.Name ).ToList();

            dgIcons.DataSource = result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current selected icon.
        /// </summary>
        public Icon SelectedIcon { get; private set; }

        /// <summary>
        /// Gets the pack name for which the control is attached.
        /// </summary>
        public string PackName { get; }

        #endregion
    }
}
