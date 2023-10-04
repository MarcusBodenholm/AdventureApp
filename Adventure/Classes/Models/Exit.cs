using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Exit
    {
        public int ID { get; set; }
        public bool IsLocked { get; set; } = false;
        public int UnlockedBy { get; set; } = 1;
        public Dictionary<Directions, Location> Locations { get; set; } = new Dictionary<Directions, Location>();
        public Obstruction? Obstruction { get; set; }
        public string Inspect()
        {
            string output = "You see a door. ";
            string obstruction = Obstruction == null ? "" : $"There is {Obstruction} in the way. ";
            string locked = IsLocked ? "The door is locked. " : "The door is not locked. ";
            return output + (obstruction == "" ? locked : obstruction);
        }
    }
}
