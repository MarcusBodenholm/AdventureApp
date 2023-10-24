namespace AppLogic.DataAccess
{
    public class JsonCharacter
    {
        public string Name { get; set; } = string.Empty;
        public int[]? ItemIDs { get; set; } = null;
        public int? ContainerID { get; set; } = null;
    }
}
