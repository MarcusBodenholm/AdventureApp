using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Items UsableOn { get; set; } = Items.Unknown;
        public Items Type { get; set; } = Items.Unknown;
        public Item? SpecialItem { get; set; }
        public string Article { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
        public string Inspect()
        {
            string usableOn = UsableOn == Items.Unknown || SpecialItem == null ? "" : $"This item can be used on {UsableOn} to gain {SpecialItem.Name}";
            return $"{Description} {usableOn}";
        }
    }
}
