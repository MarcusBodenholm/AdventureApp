namespace Adventure.Classes.Data
{
    public class JsonLocation
    {
        public string Name { get; set; } = string.Empty;
        public int ID { get; set; } = -1;
        public string Description { get; set; } = string.Empty;
        public int[]? ContainerIDs { get; set; } = null;
        public string[]? Directions { get; set; } = null;
        public int[]? ExitIDs { get; set; } = null;
        public string Article { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; } = false;
        public int[]? ItemIDs { get; set; } = null;

    }
}
