using Adventure.Enums;

namespace Adventure.Classes
{
    public class ParsedText
    {
        public Items ItemOne { get; set; } = Items.Unknown;
        public Items ItemTwo { get; set; } = Items.Unknown;
        public Commands Command { get; set; } = Commands.Unknown;
        public Obstructions Obstruction { get; set; } = Obstructions.Unknown;
        public Directions Direction { get; set; } = Directions.Unknown;
        public Containers Container { get; set; } = Containers.Unknown;
        public string Remaining { get; set; } = string.Empty;
        public string ItemOneText { get; set; } = "";
        public string ItemTwoText { get; set; } = "";
        public string CommandText { get; set; } = "";
        public string ObstructionText { get; set; } = "";
        public string DirectionText { get; set; } = "";
        public string ContainerText { get; set; } = "";
    }
}
