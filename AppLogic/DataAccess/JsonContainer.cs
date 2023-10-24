namespace AppLogic.DataAccess
{
    public class JsonContainer
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool Liftable { get; set; } = false;
        public int[]? ItemIDs { get; set; } = null;
    }
}
