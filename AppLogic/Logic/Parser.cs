using AppLogic.Enums;
using AppLogic.Models;
using System.Reflection.Metadata;
using System.Security.Permissions;

namespace AppLogic.Logic
{
    public static class Parser
    {
        private readonly static Dictionary<string, Direction> DirectionDefinitions = new()
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
        private static Dictionary<string, string> ObstructionDefinitions = new();
        private static Dictionary<string, Command> CommandDefinitions = new()
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

        private static Dictionary<string, string> ItemDefinitions = new();
        private static Dictionary<string, string> ContainerDefinitions = new();
        private static Dictionary<string, string> NpcDefinitions = new();
        public static void UpdateContainerIdentifiers(List<Container> allContainers)
        {
            ContainerDefinitions.Clear();
            foreach (Container container in allContainers)
            {
                string type = container.Type;
                foreach (string identifier in container.Identifiers)
                {
                    ContainerDefinitions.Add(identifier, type);
                }
            }
        }
        public static void UpdateItemIdentifiers(List<Item> allItems)
        {
            ItemDefinitions.Clear();
            foreach (Item item in allItems)
            {
                string type = item.Type;
                foreach (string identifier in item.Identifiers)
                {
                    ItemDefinitions.Add(identifier, type);
                }
            }
        }
        public static void UpdateNPCIdentifiers(List<NPC> allNPCs)
        {
            NpcDefinitions.Clear();
            foreach (NPC npc in allNPCs)
            {
                string type = npc.Type;
                foreach (string identifier in npc.Identifiers)
                {
                    NpcDefinitions.Add(identifier, type);
                }
            }
        }
        public static void UpdateObstructionIdentifiers(List<Obstruction> allObstructions)
        {
            ObstructionDefinitions.Clear();
            foreach (Obstruction obs in allObstructions)
            {
                string type = obs.Type;
                foreach (string identifier in obs.Identifiers)
                {
                    ObstructionDefinitions.Add(identifier, type);
                }
            }
        }
        public static string NPC(string input)
        {
            string text = input.ToLower();
            if (NpcDefinitions.ContainsKey(text))
            {
                return NpcDefinitions[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static string Container(string input)
        {
            string text = input.ToLower();
            if (ContainerDefinitions.ContainsKey(text))
            {
                return ContainerDefinitions[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static Direction Direction(string input)
        {
            string text = input.ToLower();

            if (DirectionDefinitions.ContainsKey(text))
            {
                return DirectionDefinitions[text];
            }
            else 
            {
                return Enums.Direction.Unknown;
            }
        }
        public static Command Command(string input)
        {
            string text = input.ToLower();

            bool inDictionary = CommandDefinitions.ContainsKey(text);
            if (inDictionary)
            {
                return CommandDefinitions[text];
            }
            else
            {
                return Enums.Command.Unknown;
            }
        }
        public static string Item(string input)
        {
            string text = input.ToLower();
            if (ItemDefinitions.ContainsKey(text))
            {
                return ItemDefinitions[text];
            }
            else
            {
                return string.Empty;
            }
        }
        public static string Obstruction(string text)
        {
            if (ObstructionDefinitions.ContainsKey(text))
            {
                return ObstructionDefinitions[text];
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
            foreach (string direction in DirectionDefinitions.Keys)
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
            foreach (string obstruction in ObstructionDefinitions.Keys)
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
            foreach (string command in CommandDefinitions.Keys)
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
            foreach (string item in ItemDefinitions.Keys)
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
            foreach (string container in ContainerDefinitions.Keys)
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
            foreach (string npc in NpcDefinitions.Keys)
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
