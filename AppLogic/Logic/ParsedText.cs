using AppLogic.Enums;

namespace AppLogic.Logic
{
    public class ParsedText
    {
        public string ItemOne { get; set; } = string.Empty;
        public string ItemTwo { get; set; } = string.Empty;
        public Commands Command { get; set; } = Commands.Unknown;
        public Obstructions Obstruction { get; set; } = Obstructions.Unknown;
        public Directions Direction { get; set; } = Directions.Unknown;
        public string Container { get; set; } = string.Empty;
        public NPCs NPC { get; set; } = NPCs.Unknown;
        public string Remaining { get; set; } = string.Empty;
        public string ItemOneText { get; set; } = "";
        public string ItemTwoText { get; set; } = "";
        public string CommandText { get; set; } = "";
        public string ObstructionText { get; set; } = "";
        public string DirectionText { get; set; } = "";
        public string ContainerText { get; set; } = "";
        public string NPCText { get; set; } = "";
        public bool HasOnly(string text)
        {
            string skip = text.ToLower();
            bool output = true;
            if (!skip.Contains("itemone") && ItemOne != string.Empty) output = false;
            if (!skip.Contains("itemtwo") && ItemTwo != string.Empty) output = false;
            if (!skip.Contains("command") && Command != Commands.Unknown) output = false;
            if (!skip.Contains("obstruction") && Obstruction != Obstructions.Unknown) output = false;
            if (!skip.Contains("direction") && Direction != Directions.Unknown) output = false;
            if (!skip.Contains("container") && Container != string.Empty) output = false;
            return output;
        }
        public bool RemainingContains(string text)
        {
            string[] toCheck = text.ToLower().Split(" ");
            foreach (string check in toCheck)
            {
                if (Remaining.Contains(check))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
