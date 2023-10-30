using AppLogic.Enums;

namespace AppLogic.Models
{
    public class Event
    {
        public string Name { get; set; } = string.Empty;
        public int ID { get; set; } = -1;
        public string EventText { get; set; } = string.Empty;
        public int? Obstruction { get; set; } = null;
        public Direction Direction { get; set; } = Direction.Unknown;
    }
    public class Monster
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AttackDescription { get; set; } = string.Empty;
        public int MaxHP { get; set; } = 0;
        public int HP { get; set; } = 0;
        public int Damage { get; set; } = 0;
        public bool IsAlive { get; set; } = true;
        public Monster(string name, string description, int maxHP, int damage)
        {
            Name = name;
            Description = description;
            MaxHP = maxHP;
            HP = maxHP;
            Damage = damage;

        }
        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP < 0) IsAlive = false;
        }
        public int GetHPPercentage()
        {
            return HP / MaxHP;
        }
        public string Inspect()
        {
            string output = Description + $"\n{GetHealthDescription()}";
            return output;
        }
        public string GetHealthDescription()
        {
            string output = "";
            int hpPercentage = GetHPPercentage();
            if (hpPercentage == 100) output += $"The {Name.ToLower()} looks perfectly healthy.";
            if (hpPercentage < 100 && hpPercentage > 75) output += $"The {Name.ToLower()} has barely taken a scratch.";
            if (hpPercentage <= 75 && hpPercentage > 50) output += $"The {Name.ToLower()} has a few wounds.";
            if (hpPercentage <= 50 && hpPercentage > 25) output += $"The {Name.ToLower()} has taken a beating.";
            if (hpPercentage <= 25 && hpPercentage > 10) output += $"The {Name.ToLower()} has lost a lot of blood.";
            if (hpPercentage <= 10) output += $"The {Name.ToLower()} is close to dead.";
            return output;

        }
    }
}
