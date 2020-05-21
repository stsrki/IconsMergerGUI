#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IconsMergerGUI.Loaders;
using LiteDB;
#endregion

namespace IconsMergerGUI
{
    public class IconLoaderFactory
    {
        public static IconLoader Create( LiteDatabase db, string packName )
        {
            if ( packName == Constants.FontAwesome )
                return new FontAwesomeLoader( db, packName );
            else if ( packName == Constants.Material )
                return new MaterialLoader( db, packName );
            else if ( packName == Constants.OpenIconic )
                return new OpenIconicLoader( db, packName );

            return null;
        }
    }
}
