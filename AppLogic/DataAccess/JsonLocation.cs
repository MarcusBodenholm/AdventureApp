namespace AppLogic.DataAccess
{
    public class JsonLocation
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; } = false;
        public int[]? ContainerIDs { get; set; } = null;
        public string[]? Directions { get; set; } = null;
        public int[]? ExitIDs { get; set; } = null;
        public int[]? ItemIDs { get; set; } = null;
        public bool HasEntered { get; set; } = false;
        public int? EventID { get; set; } = null;
        public bool NPC { get; set; } = true;

    }
}
