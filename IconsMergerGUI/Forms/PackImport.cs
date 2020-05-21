#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace IconsMergerGUI.Forms
{
    public partial class PackImport : Form
    {
        #region Members

        #endregion

        #region Constructors

        public PackImport()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void PackImport_Load( object sender, EventArgs e )
        {
            cboPack.Items.Add( Constants.FontAwesome );
            cboPack.Items.Add( Constants.Material );
            cboPack.Items.Add( Constants.OpenIconic );
            cboPack.SelectedIndex = 0;
        }

        private void btnOpenDirectory_Click( object sender, EventArgs e )
        {
            using ( var dialog = new FolderBrowserDialog() )
            {
                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    SelectedPath = txtDirectory.Text = dialog.SelectedPath;

                    if ( SelectedPath.Contains( "fontawesome" ) )
                        cboPack.SelectedIndex = 0;
                    else if ( SelectedPath.Contains( "material" ) )
                        cboPack.SelectedIndex = 1;
                    else if ( SelectedPath.Contains( "open-iconic" ) )
                        cboPack.SelectedIndex = 2;
                }
            }
        }

        private void txtDirectory_TextChanged( object sender, EventArgs e )
        {

        }

        private void cboPack_SelectedIndexChanged( object sender, EventArgs e )
        {
            PackName = cboPack.SelectedItem.ToString();
        }

        #endregion

        #region Properties

        public string SelectedPath { get; private set; }

        public string PackName { get; private set; }

        #endregion
    }
}
