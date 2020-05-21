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
    public partial class MapName : Form
    {
        #region Members

        #endregion

        #region Constructors

        public MapName( string newIconName, IReadOnlyCollection<Image> images )
        {
            InitializeComponent();

            txtNewIconName.Text = newIconName;

            int left = 0;

            foreach ( var image in images )
            {
                pnlImages.Controls.Add( new PictureBox
                {
                    Size = new Size( 24, 24 ),
                    Left = left,
                    Image = image,
                } );

                left += 30;
            }
        }

        #endregion

        #region Events

        private void MapName_Load( object sender, EventArgs e )
        {
            txtNewIconName.Focus();
        }

        #endregion

        #region Properties

        public string NewIconName => txtNewIconName.Text;

        #endregion
    }
}
