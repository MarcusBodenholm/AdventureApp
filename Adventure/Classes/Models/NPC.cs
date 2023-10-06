namespace Adventure.Classes.Models
{
    public class NPC
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        private int ItemID { get; set; } = -1;
        private int GiftItemID { get; set; } = -1;
        private Dictionary<string, string> Conversations { get; set; } = new();

    }
}
