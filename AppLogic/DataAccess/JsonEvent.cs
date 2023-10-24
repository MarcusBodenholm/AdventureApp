namespace AppLogic.DataAccess
{
    public class JsonEvent
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string EventText { get; set; } = string.Empty;
        public int? Obstruction { get; set; } = null;
        public string Direction { get; set; } = string.Empty;
    }
}
