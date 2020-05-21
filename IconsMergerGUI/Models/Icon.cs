#region Using directives
using LiteDB;
#endregion

namespace IconsMergerGUI.Models
{
    public class Icon
    {
        public ObjectId Id { get; set; }

        public string Pack { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public byte[] Image { get; set; }
    }
}
