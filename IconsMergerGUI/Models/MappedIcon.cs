#region Using directives
using System.Collections.Generic;
using LiteDB;
#endregion

namespace IconsMergerGUI.Models
{
    public class MappedIcon
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string NormalizedMappedName { get; set; }

        public List<Icon> Icons { get; set; }
    }
}
