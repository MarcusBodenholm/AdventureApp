namespace AppLogic.DataAccess
{
    public class JsonObstruction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClearedBy { get; set; }
        public string Article { get; set; }
        public string Type { get; set; }

    }
    public class JsonEvent
    {
        public string Name { get; set; } = string.Empty;
        public int ID { get; set; } = -1;
        public string EventText { get; set; } = string.Empty;
        public int? Obstruction { get; set; } = null;
        public string Direction { get; set; } = string.Empty;
    }
}
