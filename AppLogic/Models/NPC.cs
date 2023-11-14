using AppLogic.Enums;
using System.Diagnostics;

namespace AppLogic.Models
{
    public class NPC
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Greeting { get; set; } = string.Empty;
        public string Farewell { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<string> Identifiers { get; set; } = new();
        public Dictionary<int, int>? Gifts { get; set; } = null;
        public Dictionary<string, string> Conversations { get; set; } = new();
        public (string, int) ReceiveGift(int id)
        {
            if (Gifts == null) return ("There's nothing that you can give me that I desire.", -1);
            if (Gifts.ContainsKey(id))
            {
                return ($"{Name}: Thank you for this kind gift. Please take this in exchange!", Gifts[id]);
            }
            else
            {
                return ("Unfortunately this holds no value to me.", -1);
            }
        }
        public string Talk(string input)
        {
            foreach (string topic in Conversations.Keys)
            {
                if (input.Contains(topic))
                {
                    return $"{Name}: {Conversations[topic]}";
                }
            }
            return $"{Name}: Sadly I have no answers to that.";
        }
        public string Inspect()
        {
            return Description;
        }
    }
}
