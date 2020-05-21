#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IconsMergerGUI.Models;
using IconsMergerGUI.Utils;
using LiteDB;
using Svg;
#endregion

namespace IconsMergerGUI
{
    public abstract class IconLoader
    {
        protected readonly string pack;

        protected readonly ILiteCollection<Icon> iconCollection;

        protected readonly ILiteCollection<MappedIcon> mappedIconCollection;

        public IconLoader( LiteDatabase db, string pack )
        {
            this.pack = pack;

            iconCollection = db.GetCollection<Icon>( Constants.IconCollection );
            mappedIconCollection = db.GetCollection<MappedIcon>( Constants.MappedIconCollection );
        }

        public void Load( string path )
        {
            var files = FindFiles( path );

            if ( files == null )
                return;

            foreach ( var file in files )
            {
                var svgDoc = SvgDocument.Open<SvgDocument>( file );

                var name = GetIconName( file );
                var normalizedName = GetIconNormalizedName( name );

                if ( iconCollection.Exists( x => x.Pack == pack && x.Name == name )
                    /*|| mappedIconCollection.Exists( x => x.Icons.Exists( i => i.Pack == pack && i.Name == name ) )*/ )
                    continue;

                using ( var image = svgDoc.Draw( 24, 24 ) )
                {
                    var data = ImageTools.ImageToByteArray( image );

                    iconCollection.Insert( new Icon
                    {
                        Pack = pack,
                        Name = name,
                        NormalizedName = normalizedName,
                        Image = data,
                    } );
                }
            }
        }

        protected abstract string GetIconName( string filename );

        protected abstract string GetIconNormalizedName( string name );

        protected abstract string[] FindFiles( string path );
    }
}
