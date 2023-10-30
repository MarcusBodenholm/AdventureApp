using AppLogic.Enums;
using AppLogic.DataAccess;

namespace AppLogic.Models
{
    public class Item
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UsableOn { get; set; } = -1;
        public string Type { get; set; } = string.Empty;
        public List<string> Identifiers { get; set; } = new();
        public int SpecialItem { get; set; } = -1;
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
    public interface IEquippable
    {

    }
    public interface IConsumable
    {

    }
    public enum Armors
    {
        Helmet,
        Torso,
        Legs,
        Arms,
        Unknown
    }
    public enum WeaponSlots
    {
        LeftHand,
        RightHand,
        TwoHanded,
        Unknown
    }

    public class Armor : Item, IEquippable
    {
        public int Value { get; set; } = 0;
    }
    public class Weapon : Item, IEquippable
    {
        public int Damage { get; set; } = 0;
    }
    public class Consumable : Item, IConsumable
    {
        public int HealthRestore { get; set; } = 0;
    }
    public class Equipment
    {
        public Armor? Helmet { get; set; } = null;
        public Armor? Torso { get; set; } = null;
        public Armor? Legs { get; set; } = null;
        public Armor? Arms { get; set; } = null;
        public Weapon? LeftHand { get; set; } = null;
        public Weapon? RightHand { get; set; } = null;
        public Weapon? TwoHanded { get; set; } = null;
        public int ArmorValue()
        {
            int output = 0;
            if (Helmet != null) output += Helmet.Value; 
            if (Torso != null) output += Torso.Value;
            if (Legs != null) output += Legs.Value;
            if (Arms != null) output += Arms.Value;
            return output;

        }

    }
}
