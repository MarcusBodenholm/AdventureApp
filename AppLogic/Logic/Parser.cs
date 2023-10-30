using AppLogic.Enums;
using System.Security.Permissions;

namespace AppLogic.Logic
{
    public static class Parser
    {
        private readonly static Dictionary<string, Direction> directions = new()
        {
            {"north door", Enums.Direction.North },
            {"south door", Enums.Direction.South },
            {"east door", Enums.Direction.East },
            {"west door", Enums.Direction.West },
            {"north", Enums.Direction.North },
            {"south", Enums.Direction.South },
            {"east", Enums.Direction.East },
            {"west", Enums.Direction.West }

        };
        private readonly static Dictionary<string, string> obstructions = new()
        {
            {"fire", "fire" },
            {"boulder", "boulder"},
            {"barricade", "barricade" }
        };
        private readonly static Dictionary<string, Command> commands = new()
        {
            {"a really long way to say take", Enums.Command.Take },
            {"look at", Enums.Command.Inspect },
            {"put", Enums.Command.Store },
            {"pick up", Enums.Command.Take },
            {"throw away", Enums.Command.Drop },
            {"grab", Enums.Command.Take },
            {"use", Enums.Command.Use },
            {"take", Enums.Command.Take},
            {"drop", Enums.Command.Drop },
            {"move", Enums.Command.Move },
            {"go", Enums.Command.Move },
            {"walk", Enums.Command.Move },
            {"inventory", Enums.Command.Inventory },
            {"inspect", Enums.Command.Inspect },
            {"check", Enums.Command.Check },
            {"translocate", Enums.Command.Move },
            {"advance", Enums.Command.Move },
            {"manoeuver", Enums.Command.Move },
            {"run", Enums.Command.Move },
            {"crawl", Enums.Command.Move },
            {"teleport", Enums.Command.Move },
            {"reposition", Enums.Command.Move },
            {"jog", Enums.Command.Move },
            {"sprint", Enums.Command.Move },
            {"look", Enums.Command.Inspect },
            {"trip", Enums.Command.Move },
            {"fall", Enums.Command.Move },
            {"collapse", Enums.Command.Move },
            {"roll", Enums.Command.Move },
            {"head", Enums.Command.Move },
            {"utilize", Enums.Command.Use },
            {"throw", Enums.Command.Drop },
            {"discard", Enums.Command.Drop },
            {"get", Enums.Command.Take },
            {"examine", Enums.Command.Inspect },
            {"study", Enums.Command.Inspect },
            {"read", Enums.Command.Inspect },
            {"store", Enums.Command.Store },
            {"give", Enums.Command.Give },
            {"gift", Enums.Command.Give },
            {"talk", Enums.Command.Talk },
            {"speak", Enums.Command.Talk },
            {"stop talking", Enums.Command.Stop },
            {"stop", Enums.Command.Stop },
            {"help", Enums.Command.Help },
        };

        private readonly static Dictionary<string, string> items = new()
        {
            {"painted figurine", "painted figurine" },
            {"paintedfigurine",  "painted figurine" },
            {"fire extinguisher tank", "fire extinguisher tank" },
            {"fireextinguishertank", "fire extinguisher tank" },
            {"second key fragment", "second key fragment" },
            {"secondkeyfragment", "second key fragment" },
            {"green key", "green key" },
            {"greenkey", "green key" },
            {"basket with figurine", "basket with figurine" },
            {"basketwithfigurine", "basket with figurine" },
            {"basket of gifts", "basket of gifts" },
            {"basketofgifts", "basket of gifts" },
            {"lump of dirt", "lump of dirt" },
            {"dirtlump", "lump of dirt" },
            {"key fragment", "key fragment" },
            {"keyfragment", "key fragment" },
            {"wine bottle", "wine bottle" },
            {"winebottle", "wine bottle" },
            {"purple key", "purple key" },
            {"purplekey", "purple key" },
            {"fire extinguisher", "fire extinguisher" },
            {"opened wine bottle", "opened wine bottle" },
            {"openedwinebottle", "opened wine bottle" },
            {"small key", "small key" },
            {"smallkey", "small key" },
            {"corkscrew", "corkscrew" },
            {"opened bottle", "opened bottle" },
            {"openedbottle", "opened bottle" },
            {"bottle", "bottle" },
            {"extinguisher", "fire extinguisher" },
            {"shovel", "shovel" },
            {"key", "key" },
            {"note", "note" },
            {"instructions", "instructions" },
            {"pickaxe", "pickaxe" },
            {"crowbar", "crowbar" },
            {"carving knife", "carving knife" },
            {"carvingknife", "carving knife" },
            {"wood", "wood" },
            {"paint", "paint" },
            {"figurine", "figurine" },
            {"diary", "diary" },
            {"handle", "handle" },
            {"flowers", "flowers" },
            {"basket", "basket" },
        };
        private readonly static Dictionary<string, string> containers = new()
        {
            {"cupboard", "cupboard" },
            {"small box", "small box" },
            {"shoebox", "small box" },
            {"kitchen counter", "kitchen counter" },
            {"kitchencounter", "kitchen counter" },
            {"counter", "counter" },
            {"desk", "desk" },
            {"box", "small box" }
        };
        private readonly static Dictionary<string, string> npcs = new()
        {
            {"rhys", "rhys" },
            {"old man", "rhys" },
        };
        public static string NPC(string input)
        {
            string text = input.ToLower();
            if (npcs.ContainsKey(text))
            {
                return npcs[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static string Container(string input)
        {
            string text = input.ToLower();
            if (containers.ContainsKey(text))
            {
                return containers[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static Direction Direction(string input)
        {
            string text = input.ToLower();

            if (directions.ContainsKey(text))
            {
                return directions[text];
            }
            else 
            {
                return Enums.Direction.Unknown;
            }
        }
        public static Command Command(string input)
        {
            string text = input.ToLower();

            bool inDictionary = commands.ContainsKey(text);
            if (inDictionary)
            {
                return commands[text];
            }
            else
            {
                return Enums.Command.Unknown;
            }
        }
        public static string Item(string input)
        {
            string text = input.ToLower();
            if (items.ContainsKey(text))
            {
                return items[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static string Obstruction(string text)
        {
            if (obstructions.ContainsKey(text))
            {
                return obstructions[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static ParsedText ParseText(string input)
        {
            ParsedText parsed = new();
            input = ParseCommand(input, parsed);
            input = ParseDirection(input, parsed);
            input = ParseItem(input, parsed, 1);
            input = ParseItem(input, parsed, 2);
            input = ParseObstruction(input, parsed);
            input = ParseContainer(input, parsed);
            input = ParseNPC(input, parsed);
            parsed.Remaining = input.Replace(".", "");
            return parsed;
        }
        private static string ConsumeTextAtStart(string input, string toConsume)
        {
            return input.Substring(toConsume.Length).Trim();
        }
        private static string ConsumeTextAtEnd(string input, string toConsume)
        {
            int idx = input.Length -toConsume.Length- 1;
            return idx != -1 ? input.Substring(0,idx).Trim() : "";
        }
        private static string ParseDirection(string input, ParsedText parsed)
        {
            foreach (string direction in directions.Keys)
            {
                if (input.EndsWith(direction))
                {
                    input = ConsumeTextAtEnd(input, direction);
                    parsed.Direction = Direction(direction);
                    parsed.DirectionText = direction;
                    return input;
                }
            }
            return input;
        }
        private static string ParseObstruction(string input, ParsedText parsed)
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
        private static string ParseCommand(string input, ParsedText parsed)
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
        private static string ParseItem(string input, ParsedText parsed, int itemNr)
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
        private static string ParseContainer(string input, ParsedText parsed)
        {
            foreach (string container in containers.Keys)
            {
                if (input.EndsWith(container))
                {
                    input = ConsumeTextAtEnd(input, container);
                    parsed.Container = Container(container);
                    parsed.ContainerText = container;
                    return input;
                }
            }
            return input;
        }
        private static string ParseNPC(string input, ParsedText parsed)
        {
            foreach (string npc in npcs.Keys)
            {
                if (input.EndsWith(npc))
                {
                    input = ConsumeTextAtEnd(input, npc);
                    parsed.NPC = NPC(npc);
                    parsed.NPCText = npc;
                    return input;
                }
            }
            return input;
        }
    }
}
