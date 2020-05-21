#region Using directives
using LiteDB;
#endregion

namespace IconsMergerGUI.Models
{
    public class Pack
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
