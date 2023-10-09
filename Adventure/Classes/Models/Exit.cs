using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Exit
    {
        public int ID { get; set; }
        public bool IsLocked { get; set; } = false;
        public int UnlockedBy { get; set; } = 1;
        public string Description { get; set; } = string.Empty;
        public Dictionary<Directions, int> Locations { get; set; } = new();
        public Obstruction? Obstruction { get; set; }
        public string Inspect(Directions direction)
        {
            string output = $"You see a {Description}. ";
            string obstruction = Obstruction == null ? "" : $"There is {Obstruction} in the way. ";
            Location otherSide = Data.Data.GetLocation(Locations[direction]);
            if (otherSide == null) return $"Something went wrong with {Locations[direction]}";
            string locked = IsLocked ? $"The {Description} is locked. " : $"The {Description} is not locked. ";
            locked += IsLocked ? "" : $"On the other side is {otherSide}";
            return output + (obstruction == "" ? locked : obstruction);
        }
        public string Unlock(Item item)
        {
            IsLocked = false;
            return $"You unlocked the door using {item}." +
                   $"\nThe {item.Name.ToLower()} was lost in the process.";
        }
    }
}
