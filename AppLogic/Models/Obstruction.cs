using AppLogic.Enums;

namespace AppLogic.Models
{
    public class Obstruction
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int>? ClearedBy { get; set; } = new();
        public string Article { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<string> Identifiers { get; set; } = new();
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
    }
}
