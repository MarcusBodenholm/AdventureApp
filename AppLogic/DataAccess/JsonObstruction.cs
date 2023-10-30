namespace AppLogic.DataAccess
{
    public class JsonObstruction
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string[]? Identifiers { get; set; } = null;
        public int[]? ClearedBy { get; set; } = null;

    }
}
