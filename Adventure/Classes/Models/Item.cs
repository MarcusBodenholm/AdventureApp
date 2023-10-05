using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UsableOn { get; set; } = string.Empty;
        public Items Type { get; set; }
        public Item? SpecialItem { get; set; }
        public string Article { get; set; }
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
        public string Inspect()
        {
            string usableOn = UsableOn == string.Empty || SpecialItem == null ? "" : $"This item can be used on {UsableOn} to gain {SpecialItem.Name}";
            return $"{Description} {usableOn}";
        }
    }
}
