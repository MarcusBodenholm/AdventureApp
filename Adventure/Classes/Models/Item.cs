using Adventure.Enums;
using Adventure.Classes.Data;

namespace Adventure.Classes.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Items UsableOn { get; set; } = Items.Unknown;
        public Items Type { get; set; } = Items.Unknown;
        public int SpecialItem { get; set; } = -1;
        public string Article { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
        public string Inspect()
        {
            Item? specialItem = Data.Data.GetItem(SpecialItem);
            string usableOn = UsableOn == Items.Unknown || specialItem == null ? "" : $"This item can be used on {UsableOn} to gain {specialItem.Name}";
            return $"{Description} {usableOn}";
        }
    }
}
