using Adventure.Enums;
using System.Diagnostics;

namespace Adventure.Classes.Models
{
    public class NPC
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Greeting { get; set; } = string.Empty;
        public string Farewell { get; set; } = string.Empty;
        public NPCs Type { get; set; } = NPCs.Unknown;
        public int ItemID { get; set; } = -1;
        public int GiftItemID { get; set; } = -1;
        public Dictionary<string, string> Conversations { get; set; } = new();
        public (string, int) ReceiveGift(int id)
        {
            if (id != GiftItemID)
            {
                return ("Unfortunately this holds no value to me.", -1);
            }
            else
            {
                return ($"{Name}: Thank you for this kind gift. Please take this in exchange!", ItemID);
            }
        }
    }
}
