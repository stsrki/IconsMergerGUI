#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace IconsMergerGUI.Forms
{
    public partial class PackSelect : Form
    {
        #region Members

        #endregion

        #region Constructors

        public PackSelect( string[] packs )
        {
            InitializeComponent();

            if ( packs.Length > 0 )
            {
                foreach ( var pack in packs )
                {
                    cboPack.Items.Add( pack );
                }

                cboPack.SelectedIndex = 0;
            }
        }

        #endregion

        #region Events

        private void cboPack_SelectedIndexChanged( object sender, EventArgs e )
        {
            PackName = cboPack.SelectedItem.ToString();
        }

        #endregion

        #region Methods

        #endregion

        #region Properties

        public string PackName { get; private set; }

        #endregion
    }
}
