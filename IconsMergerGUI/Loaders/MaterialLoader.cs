#region Using directives
using System.Collections.Generic;
using System.IO;
using LiteDB;
#endregion

namespace IconsMergerGUI.Loaders
{
    public class MaterialLoader : IconLoader
    {
        public MaterialLoader( LiteDatabase db, string pack )
            : base( db, pack )
        {
        }

        protected override string GetIconName( string path )
        {
            var filename = Path.GetFileNameWithoutExtension( path );
            return filename.Substring( 3, filename.Length - 8 );
        }

        protected override string GetIconNormalizedName( string name )
        {
            return name.Replace( "_", "-" );
        }

        protected override string[] FindFiles( string path )
        {
            var filenames = new List<string>();

            var directories = Directory.GetDirectories( path, @"*production*", SearchOption.AllDirectories );

            foreach ( var directory in directories )
            {
                var files = Directory.GetFiles( directory, "*24px.svg" );

                filenames.AddRange( files );
            }

            return filenames.ToArray();
        }
    }
}
