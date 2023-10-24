using AppLogic.Enums;
using System.Security.Permissions;

namespace AppLogic.Logic
{
    public static class Parser
    {
        private readonly static Dictionary<string, Directions> directions = new()
        {
            {"north door", Directions.North },
            {"south door", Directions.South },
            {"east door", Directions.East },
            {"west door", Directions.West },
            {"north", Directions.North },
            {"south", Directions.South },
            {"east", Directions.East },
            {"west", Directions.West }

        };
        private readonly static Dictionary<string, Obstructions> obstructions = new()
        {
            {"fire", Obstructions.Fire },
            {"boulder", Obstructions.Boulder},
            {"barricade", Obstructions.Barricade }
        };
        private readonly static Dictionary<string, Commands> commands = new()
        {
            {"a really long way to say take", Commands.Take },
            {"look at", Commands.Inspect },
            {"put", Commands.Store },
            {"pick up", Commands.Take },
            {"throw away", Commands.Drop },
            {"grab", Commands.Take },
            {"use", Commands.Use },
            {"take", Commands.Take},
            {"drop", Commands.Drop },
            {"move", Commands.Move },
            {"go", Commands.Move },
            {"walk", Commands.Move },
            {"inventory", Commands.Inventory },
            {"inspect", Commands.Inspect },
            {"check", Commands.Check },
            {"translocate", Commands.Move },
            {"advance", Commands.Move },
            {"manoeuver", Commands.Move },
            {"run", Commands.Move },
            {"crawl", Commands.Move },
            {"teleport", Commands.Move },
            {"reposition", Commands.Move },
            {"jog", Commands.Move },
            {"sprint", Commands.Move },
            {"look", Commands.Inspect },
            {"trip", Commands.Move },
            {"fall", Commands.Move },
            {"collapse", Commands.Move },
            {"roll", Commands.Move },
            {"head", Commands.Move },
            {"utilize", Commands.Use },
            {"throw", Commands.Drop },
            {"discard", Commands.Drop },
            {"get", Commands.Take },
            {"examine", Commands.Inspect },
            {"study", Commands.Inspect },
            {"read", Commands.Inspect },
            {"store", Commands.Store },
            {"give", Commands.Give },
            {"gift", Commands.Give },
            {"talk", Commands.Talk },
            {"speak", Commands.Talk },
            {"stop talking", Commands.Stop },
            {"stop", Commands.Stop },
            {"help", Commands.Help },
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
        private readonly static Dictionary<string, NPCs> npcs = new()
        {
            {"rhys", NPCs.Rhys },
            {"person", NPCs.Rhys },
            {"old man", NPCs.Rhys },
            {"oldman", NPCs.Rhys }
        };
        public static NPCs NPC(string input)
        {
            string text = input.ToLower();
            if (npcs.ContainsKey(text))
            {
                return npcs[text];
            }
            else
            {
                return NPCs.Rhys;
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
