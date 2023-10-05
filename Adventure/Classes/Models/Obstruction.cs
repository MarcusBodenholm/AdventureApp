using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Obstruction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClearedBy { get; set; }
        public string Article { get; set; }
        public Obstructions Type { get; set; }
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
    }
}
