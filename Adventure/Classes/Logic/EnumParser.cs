using Adventure.Enums;

namespace Adventure.Classes
{
    public static class EnumParser
    {
        public static Directions Direction(string input)
        {
            Dictionary<string, Directions> directions = new Dictionary<string, Directions>()
            {
                {"north", Directions.North },
                {"south", Directions.South },
                {"east", Directions.East },
                {"west", Directions.West }
            };
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
            Dictionary<string, Commands> commands = new Dictionary<string, Commands>()
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
            };
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
            Dictionary<string, Items> items = new Dictionary<string, Items>()
            {
                {"fire extinguisher", Items.Extinguisher },
                {"corkscrew", Items.Corkscrew },
                {"bottle", Items.Bottle },
                {"opened bottle", Items.OpenedBottle },
                {"extinguisher", Items.Extinguisher },
                {"shovel", Items.Shovel }
                
            };
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
            Dictionary<string, Obstructions> obstructions = new Dictionary<string, Obstructions>()
            {
                {"fire", Obstructions.Fire },
                { "boulder", Obstructions.Boulder}
            };
            if (obstructions.ContainsKey(text))
            {
                return obstructions[text];
            }
            else
            {
                return Obstructions.Unknown;
            }
        }

    }
}
