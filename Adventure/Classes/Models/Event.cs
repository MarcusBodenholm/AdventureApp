using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Event
    {
        public string Name { get; set; } = string.Empty;
        public int ID { get; set; } = -1;
        public string EventText { get; set; } = string.Empty;
        public int? Obstruction { get; set; } = null;
        public Directions Direction { get; set; } = Directions.Unknown;
    }
}
