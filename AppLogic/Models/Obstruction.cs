using AppLogic.Enums;

namespace AppLogic.Models
{
    public class Obstruction
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ClearedBy { get; set; } = -1;
        public string Article { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
    }
}
