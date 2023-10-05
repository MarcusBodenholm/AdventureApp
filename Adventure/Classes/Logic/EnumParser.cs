using Adventure.Enums;
using System.Security.Permissions;

namespace Adventure.Classes
{
    public static class EnumParser
    {
        private readonly static Dictionary<string, Directions> directions = new()
        {
                {"north", Directions.North },
                {"south", Directions.South },
                {"east", Directions.East },
                {"west", Directions.West }

        };
        private readonly static Dictionary<string, Obstructions> obstructions = new()
        {
                {"fire", Obstructions.Fire },
                {"boulder", Obstructions.Boulder}
        };
        private readonly static Dictionary<string, Commands> commands = new()
        {
            {"use", Commands.Use },
            {"take", Commands.Take},
            {"drop", Commands.Drop },
            {"move", Commands.Move },
            {"go", Commands.Move },
            {"walk", Commands.Move },
            {"inventory", Commands.Inventory },
            {"inspect", Commands.Inspect },
            {"check", Commands.Check },
            {"look", Commands.Look },
            {"trip", Commands.Move },
            {"fall", Commands.Move },
            {"collapse", Commands.Move },
            {"roll", Commands.Move },
            {"head", Commands.Move },
            {"utilize", Commands.Use },
            {"throw", Commands.Drop },
            {"get", Commands.Take },
            {"examine", Commands.Examine },
            {"pick up", Commands.Take },
            {"a really long way to say take", Commands.Take }
        };

        private readonly static Dictionary<string, Items> items = new()
        {
                {"fire extinguisher", Items.Extinguisher },
                {"corkscrew", Items.Corkscrew },
                {"bottle", Items.Bottle },
                {"opened bottle", Items.OpenedBottle },
                {"extinguisher", Items.Extinguisher },
                {"shovel", Items.Shovel }

        };

        public static Directions Direction(string input)
        {
            string text = input.ToLower();

            if (directions.ContainsKey(text))
            {
                return directions[text];
            }
            else 
            {
                return Directions.Unknown;
            }
        }
        public static Commands Command(string input)
        {
            string text = input.ToLower();

            bool inDictionary = commands.ContainsKey(text);
            if (inDictionary)
            {
                return commands[text];
            }
            else
            {
                return Commands.Unknown;
            }
        }
        public static Items Item(string text)
        {
            if (items.ContainsKey(text))
            {
                return items[text];
            }
            else
            {
                return Items.Unknown;
            }
        }
        public static Obstructions Obstruction(string text)
        {
            if (obstructions.ContainsKey(text))
            {
                return obstructions[text];
            }
            else
            {
                return Obstructions.Unknown;
            }
        }
        public static Parsed ParseText(string input)
        {
            Parsed parsed = new();
            string[] inputs = input.Split(" ");
            input = ParseCommand(input, parsed);
            input = ParseDirection(input, parsed);
            input = ParseItem(input, parsed, 1);
            input = ParseItem(input, parsed, 2);
            input = ParseObstruction(input, parsed);
            parsed.Remaining = input;
            return parsed;
        }
        public static string ConsumeTextAtStart(string input, string toConsume)
        {
            return input.Substring(toConsume.Length).Trim();
        }
        public static string ConsumeTextAtEnd(string input, string toConsume)
        {
            int idx = input.Length -toConsume.Length- 1;
            return input.Substring(0,idx).Trim();
        }
        public static string ParseDirection(string input, Parsed parsed)
        {
            foreach (string direction in directions.Keys)
            {
                if (input.StartsWith(direction))
                {
                    input = ConsumeTextAtStart(input, direction);
                    parsed.Direction = Direction(direction);
                    parsed.DirectionText = direction;
                    return input;

                }
            }
            return input;
        }
        public static string ParseObstruction(string input, Parsed parsed)
        {
            foreach (string obstruction in obstructions.Keys)
            {
                if (input.EndsWith(obstruction))
                {
                    input = ConsumeTextAtEnd(input, obstruction);
                    parsed.Obstruction = Obstruction(obstruction);
                    parsed.ObstructionText = obstruction;
                    return input;

                }
            }
            return input;
        }
        public static string ParseCommand(string input, Parsed parsed)
        {
            foreach (string command in commands.Keys)
            {
                if (input.StartsWith(command))
                {
                    input = ConsumeTextAtStart(input, command);
                    parsed.Command = Command(command);
                    parsed.CommandText = command;
                    return input;
                }
            }
            return input;
        }
        public static string ParseItem(string input, Parsed parsed, int itemNr)
        {
            foreach (string item in items.Keys)
            {
                if (itemNr == 1 && input.StartsWith(item))
                {
                    input = ConsumeTextAtStart(input, item);
                    parsed.ItemOne = Item(item);
                    parsed.ItemOneText = item;
                    return input;
                }
                if (itemNr == 2 && input.EndsWith(item))
                {
                    input = ConsumeTextAtEnd(input, item);
                    parsed.ItemTwo = Item(item);
                    parsed.ItemTwoText = item;
                    return input;
                }
            }
            return input;
        }
    }

    public class Parsed
    {
        public Items ItemOne { get; set; } = Items.Unknown;
        public Items ItemTwo { get; set; } = Items.Unknown;
        public Commands Command { get; set; } = Commands.Unknown;
        public Obstructions Obstruction { get; set; } = Obstructions.Unknown;
        public Directions Direction { get; set; } = Directions.Unknown;
        public string Remaining { get; set; }
        public string ItemOneText { get; set; } = "";
        public string ItemTwoText { get; set; } = "";
        public string CommandText { get; set; } = "";
        public string ObstructionText { get; set; } = "";
        public string DirectionText { get; set; } = "";
    }
}
