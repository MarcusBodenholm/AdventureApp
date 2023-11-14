namespace AppLogic.DataAccess
{
    public class JsonNPC
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Greeting { get; set; } = string.Empty;
        public string Farewell { get; set; } = string.Empty;
        public string Handle { get; set; } = string.Empty;
        public string[]? Identifiers { get; set; } = null;
        public int[]? ItemIDs { get; set; } = null;
        public int[]? GiftItemIDs { get; set; } = null;
        public string[]? Conversations { get; set; } = null;
    }
}
