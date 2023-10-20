using AppLogic.Enums;
using AppLogic.DataAccess;

namespace AppLogic.Models
{
    public class Item
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UsableOn { get; set; } = -1;
        public Items Type { get; set; } = Items.Unknown;
        public int SpecialItem { get; set; } = -1;
        public string Article { get; set; } = string.Empty;
        public bool Persistent { get; set; } = false;
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
        public string Inspect()
        {
            Item? specialItem = Data.GetItem(SpecialItem);
            Item? usableOn = Data.GetItem(UsableOn);
            string usableOnText = UsableOn == -1 || specialItem == null ? "" : $"This item can be used on {usableOn} to gain {specialItem}.";
            return $"{Description} {usableOnText}";
        }
    }
}
