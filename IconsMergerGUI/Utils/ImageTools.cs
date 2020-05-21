#region Using directives
using System.Drawing;
using System.IO;
#endregion

namespace IconsMergerGUI.Utils
{
    public static class ImageTools
    {
        public static byte[] ImageToByteArray( Image image )
        {
            using ( var stream = new MemoryStream() )
            {
                image.Save( stream, System.Drawing.Imaging.ImageFormat.Png );
                return stream.ToArray();
            }
        }

        public static Image ByteArrayToImage( byte[] bytes )
        {
            using ( MemoryStream memstr = new MemoryStream( bytes ) )
            {
                return Image.FromStream( memstr );
            }
        }
    }
}
