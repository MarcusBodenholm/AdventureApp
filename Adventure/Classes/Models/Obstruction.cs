using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Obstruction
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Items ClearedBy { get; set; } = Items.Unknown;
        public string Article { get; set; } = string.Empty;
        public Obstructions Type { get; set; } = Obstructions.Unknown;
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
    }
}
