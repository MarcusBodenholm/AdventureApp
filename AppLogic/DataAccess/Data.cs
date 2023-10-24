using AppLogic.Models;
using AppLogic.Enums;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using AppLogic.Logic;
using AppLogic.DataAccess;

namespace AppLogic.DataAccess
{
    public static class Data
    {
        private static List<Item> AllItems { get; set; } = new();
        private static List<Location> AllLocations { get; set; } = new();
        private static List<Container> AllContainers { get; set; } = new();
        private static List<Exit> AllExits { get; set; } = new();
        private static List<Obstruction> AllObstructions { get; set;} = new();
        private static List<Event> AllEvents { get; set; } = new();
        private static string GetDirectoryPath()
        {
            string directoryPath = Environment.CurrentDirectory + @"\..\..\..\..\AppLogic\Data";
            return directoryPath;

        }
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
        };
        public static Item? GetItem(Items type)
        {
            return AllItems.Find(item => item.Type == type);
        }
        public static Item? GetItem(int id)
        {
            return AllItems.Find(item => item.ID == id);
        }
        public static Location? GetLocation(int id)
        {
            return AllLocations.Find(location => location.ID == id);
        }
        public static Container? GetContainer(Containers type)
        {
            return AllContainers.Find(container => container.Type == type);
        }
        public static Container? GetContainer(int id)
        {
            return AllContainers.Find(container => container.ID == id);
        }

        public static Exit? GetExit(int id)
        {
            return AllExits.Find(exit => exit.ID == id);
        }
        public static Obstruction? GetObstruction(int id)
        {
            return AllObstructions.Find(obs => obs.ID == id);
        }

        public static Obstruction? GetObstruction(Obstructions type)
        {
            return AllObstructions.Find(obs => obs.Type == type);
        }
        public static Event? GetEvent(int id)
        {
            return AllEvents.Find(e => e.ID == id);
        }
        public static void LoadAllData()
        {
            LoadItems();
            LoadContainers();
            LoadObstructions();
            LoadExits();
            LoadEvents();
            LoadLocations();

            SaveItems();
            SaveLocations();
            SaveExits();
            SaveContainers();
        }
        private static void LoadItems()
        {
            string filePath = @$"{GetDirectoryPath()}\Items.json";
            var json = File.ReadAllText(filePath);
            List<JsonItem>? results = JsonSerializer.Deserialize<List<JsonItem>>(json, _options);
            if (results != null)
            {
                foreach (var item in results)
                {
                    Item newItem = new Item();
                    newItem.ID = item.ID;
                    newItem.Name = item.Name;
                    newItem.Description = item.Description;
                    newItem.Article = item.Article;
                    newItem.UsableOn = item.UsableOn;
                    newItem.Type = Parser.Item(item.Type);
                    newItem.SpecialItem = item.SpecialItem;
                    newItem.Persistent = item.Persistent;
                    AllItems.Add(newItem);
                }
            }
        }
        private static void SaveItems()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedItems.json";
            List<JsonItem> toSave = new List<JsonItem>();
            foreach (Item item in AllItems)
            {
                JsonItem jsonItem = new JsonItem();
                jsonItem.Name = item.Name;
                jsonItem.ID = item.ID;
                jsonItem.Description = item.Description;
                jsonItem.Article = item.Article;
                jsonItem.UsableOn = item.UsableOn;
                jsonItem.Type = item.Type.ToString();
                jsonItem.Persistent = item.Persistent;
                jsonItem.SpecialItem = item.SpecialItem;
                toSave.Add(jsonItem);
            }
            string jsonText = JsonSerializer.Serialize(toSave, _options);
            File.WriteAllText(filePath, jsonText);
        }
        private static void LoadLocations()
        {
            string filePath = @$"{GetDirectoryPath()}\Locations.json";
            var json = File.ReadAllText(filePath);
            List<JsonLocation>? results = JsonSerializer.Deserialize<List< JsonLocation>>(json, _options);
            if (results != null)
            {
                foreach (var location in results)
                {
                    Location newLocation = new Location();
                    newLocation.ID = location.ID;
                    newLocation.Name = location.Name;
                    newLocation.Description = location.Description;
                    newLocation.Article = location.Article;
                    newLocation.IsEndPoint = location.IsEndPoint;
                    newLocation.NPC = location.NPC;
                    if (location.EventID != null)
                    {
                        newLocation.Event = GetEvent((int)location.EventID);
                    }
                    if (location.ContainerIDs != null)
                    {
                        foreach (int id in location.ContainerIDs)
                        {
                            Container? container = GetContainer(id);
                            if (container != null)
                            {
                                newLocation.Containers.Add(container);
                            }
                        }
                    }
                    if (location.Directions != null && location.ExitIDs != null)
                    {
                        for (int i = 0; i < location.Directions.Length; i++)
                        {
                            Directions direction = Parser.Direction(location.Directions[i]);
                            Exit? exit = GetExit(location.ExitIDs[i]);
                            if (exit != null)
                            {
                                newLocation.Exits.Add(direction, exit);
                            }
                        }
                    }
                    if (location.ItemIDs != null)
                    {
                        foreach (int id in location.ItemIDs)
                        {
                            Item? item = GetItem(id);
                            if (item != null)
                            {
                                newLocation.Items.Add(item);
                            }
                        }
                    }
                    AllLocations.Add(newLocation);
                }
            }
        }
        private static void SaveLocations()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedLocations.json";
            List<JsonLocation> toSave = new List<JsonLocation>();
            foreach (Location location in AllLocations)
            {
                JsonLocation jsonLocation = new JsonLocation();
                jsonLocation.ID = location.ID;
                jsonLocation.Name = location.Name;
                jsonLocation.Description = location.Description;
                jsonLocation.Article = location.Article;
                jsonLocation.IsEndPoint = location.IsEndPoint;
                jsonLocation.NPC = location.NPC;
                jsonLocation.EventID = location.Event == null ? null : location.Event.ID;
                jsonLocation.HasEntered = location.HasEntered;
                if (location.Items.Count > 0)
                {
                    jsonLocation.ItemIDs = location.Items.Select(i => i.ID).ToArray();
                }
                else jsonLocation.ItemIDs = null;
                if (location.Containers.Count > 0)
                {
                    jsonLocation.ContainerIDs = location.Containers.Select(i => i.ID).ToArray();
                } else jsonLocation.ContainerIDs = null;
                if (location.Exits.Count > 0)
                {
                    string[] jsonDirections = new string[location.Exits.Count];
                    int[] jsonExits = new int[location.Exits.Count];
                    int count = 0;
                    foreach (KeyValuePair<Directions, Exit> kvp in location.Exits)
                    {
                        jsonDirections[count] = kvp.Key.ToString();
                        jsonExits[count] = kvp.Value.ID;
                        count++;
                    }
                    jsonLocation.Directions = jsonDirections;
                    jsonLocation.ExitIDs = jsonExits;
                }
                else
                {
                    jsonLocation.Directions = null;
                    jsonLocation.ExitIDs = null;
                }
                toSave.Add(jsonLocation);
            }
            string jsonText = JsonSerializer.Serialize(toSave, _options);
            File.WriteAllText(filePath, jsonText);
        }
        private static void LoadExits()
        {
            string filePath = @$"{GetDirectoryPath()}\Exits.json";
            var json = File.ReadAllText(filePath);
            List<JsonExit>? exits = JsonSerializer.Deserialize<List<JsonExit>>(json, _options);
            if (exits != null)
            {
                foreach (var exit in exits)
                {
                    Exit newExit = new();
                    newExit.ID = exit.ID;
                    newExit.IsLocked = exit.IsLocked;
                    newExit.UnlockedBy = exit.UnlockedBy;
                    newExit.Description = exit.Description;
                    int obstructionID = exit.ObstructionID == null ? -1 : (int)exit.ObstructionID;
                    newExit.Obstruction = GetObstruction(obstructionID);
                    if (exit.Directions != null && exit.LocationIDs != null)
                    {
                        for (int i = 0; i < exit.Directions.Length; i++)
                        {
                            Directions direction = Parser.Direction(exit.Directions[i]);
                            newExit.Locations.Add(direction, exit.LocationIDs[i]);
                        }
                    }
                    AllExits.Add(newExit);
                }
            }
        }
        private static void SaveExits()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedExits.json";
            List<JsonExit> toSave = new List<JsonExit>();
            foreach (Exit exit in AllExits)
            {
                JsonExit exitJson = new JsonExit();
                exitJson.ID = exit.ID;
                exitJson.IsLocked = exit.IsLocked;
                exitJson.UnlockedBy = exit.UnlockedBy;
                exitJson.Description = exit.Description;
                if (exit.Locations.Count > 0)
                {
                    string[] directions = new string[exit.Locations.Count];
                    int[] locationIDs = new int[exit.Locations.Count];
                    int count = 0;
                    foreach (KeyValuePair<Directions, int> kvp in exit.Locations)
                    {
                        directions[count] = kvp.Key.ToString();
                        locationIDs[count] = kvp.Value;
                        count++;
                    }
                    exitJson.Directions = directions;
                    exitJson.LocationIDs = locationIDs;
                }
                else
                {
                    exitJson.Directions = null;
                    exitJson.LocationIDs = null;
                }
                exitJson.ObstructionID = exit.Obstruction == null ? null : exit.Obstruction.ID;
                toSave.Add(exitJson);
            }
            string jsonText = JsonSerializer.Serialize(toSave, _options);
            File.WriteAllText(filePath, jsonText);
        }
        private static void LoadContainers()
        {
            string filePath = @$"{GetDirectoryPath()}\Containers.json";
            var json = File.ReadAllText(filePath);
            List<JsonContainer>? containers = JsonSerializer.Deserialize<List<JsonContainer>>(json, _options);
            if (containers != null)
            {
                foreach (var container in containers)
                {
                    Container newContainer = new();
                    newContainer.ID = container.ID;
                    newContainer.Name = container.Name;
                    newContainer.Article = container.Article;
                    newContainer.Description = container.Description;
                    newContainer.Type = Parser.Container(container.Type);
                    newContainer.Liftable = container.Liftable;
                    if (container.ItemIDs != null)
                    {
                        foreach (var item in container.ItemIDs)
                        {
                            Item? itemToAdd = GetItem(item);
                            if (itemToAdd != null)
                            {
                                newContainer.AddItem(itemToAdd);
                            }
                        }
                    }
                    AllContainers.Add(newContainer);
                }
            }

        }
        private static void SaveContainers()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedContainers.json";
            List<JsonContainer> toSave = new List<JsonContainer>();
            foreach (Container container in AllContainers)
            {
                JsonContainer jsonContainer = new JsonContainer();
                jsonContainer.ID = container.ID;
                jsonContainer.Name = container.Name;
                jsonContainer.Article = container.Article;
                jsonContainer.Description = container.Description;
                jsonContainer.Type = container.Type.ToString();
                jsonContainer.Liftable  = container.Liftable;
                jsonContainer.ItemIDs = container.Items.Select(i => i.ID).ToArray();
                toSave.Add(jsonContainer);
            }
            string jsonText = JsonSerializer.Serialize(toSave, _options);
            File.WriteAllText(filePath, jsonText);

        }
        private static void LoadObstructions()
        {
            string filePath = @$"{GetDirectoryPath()}\Obstructions.json";
            var json = File.ReadAllText(filePath);
            List<JsonObstruction>? obstructions = JsonSerializer.Deserialize<List<JsonObstruction>>(json, _options);
            if (obstructions != null)
            {
                foreach (var obstruction in obstructions)
                {
                    Obstruction newObstruction = new();
                    newObstruction.ID = obstruction.ID;
                    newObstruction.Name = obstruction.Name;
                    newObstruction.Description  = obstruction.Description;
                    newObstruction.Article = obstruction.Article;
                    newObstruction.ClearedBy = Parser.Item(obstruction.ClearedBy);
                    newObstruction.Type = Parser.Obstruction(obstruction.Type);
                    AllObstructions.Add(newObstruction);
                }
            }
        }
        private static void SaveObstructions()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedObstructions.json";
            List<JsonObstruction> toSave = new List<JsonObstruction>();
            foreach (Obstruction obs in AllObstructions)
            {
                JsonObstruction jsonObs = new JsonObstruction();
                jsonObs.Name = obs.Name;
                jsonObs.ID = obs.ID;
                jsonObs.Article = obs.Article;
                jsonObs.Description = obs.Description;
                jsonObs.Type = obs.Type.ToString();
                jsonObs.ClearedBy = obs.ClearedBy.ToString();
                toSave.Add(jsonObs);
            }
            string jsonText = JsonSerializer.Serialize(toSave, _options);
            File.WriteAllText(filePath, jsonText);

        }
        private static void LoadEvents()
        {
            string filePath = @$"{GetDirectoryPath()}\Events.json";
            var json = File.ReadAllText(filePath);
            List<JsonEvent>? events = JsonSerializer.Deserialize<List<JsonEvent>>(json, _options);
            if (events != null)
            {
                foreach (var e in events)
                {
                    Event newEvent = new();
                    newEvent.EventText = e.EventText;
                    newEvent.ID = e.ID;
                    newEvent.Obstruction = e.Obstruction;
                    newEvent.Name = e.Name;
                    newEvent.Direction = Parser.Direction(e.Direction);
                    AllEvents.Add(newEvent);
                }

            }
        }
        private static void SaveEvents()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedObstructions.json";
            List<JsonEvent> toSave = new List<JsonEvent>();
            foreach (Event e in AllEvents)
            {
                JsonEvent jsonEvent = new JsonEvent();
                jsonEvent.ID = e.ID;
                jsonEvent.Name = e.Name;
                jsonEvent.EventText = e.EventText;
                jsonEvent.Obstruction = e.Obstruction;
                jsonEvent.Direction = e.Direction.ToString();
            }
            string jsonText = JsonSerializer.Serialize(toSave, _options);
            File.WriteAllText(filePath, jsonText);

        }
        private static Character LoadCharacter()
        {
            string filePath = @$"{GetDirectoryPath()}\SavedCharacter.json";
            var json = File.ReadAllText(filePath);
            JsonCharacter jsonCharacter = JsonSerializer.Deserialize<JsonCharacter>(json);
            if (jsonCharacter == null) return new Character();
            Character PC = new Character();
            PC.Name = jsonCharacter.Name;
            if (jsonCharacter.ItemIDs != null)
            {
                foreach (int id in jsonCharacter.ItemIDs)
                {
                    Item? item = GetItem(id);
                    if (item == null) continue;
                    PC.Items.Add(item);
                }
            }
            if (jsonCharacter.ContainerID != null)
            {
                Container? container = GetContainer((int)jsonCharacter.ContainerID);
                if (container != null)
                {
                    PC.CarryingContainer = container;
                }
            }
            return PC;
        }
        public static void SaveCharacter(Character PC)
        {
            string filePath = @$"{GetDirectoryPath()}\SavedCharacter.json";
            JsonCharacter jsonChar = new JsonCharacter();
            jsonChar.Name = PC.Name;
            jsonChar.ContainerID = PC.CarryingContainer == null ? null : PC.CarryingContainer.ID;
            if (PC.Items.Count > 0)
            {
                jsonChar.ItemIDs = PC.Items.Select(i => i.ID).ToArray();
            }
            else jsonChar.ItemIDs = null;
            string jsonText = JsonSerializer.Serialize(jsonChar, _options);
            File.WriteAllText(filePath, jsonText);
        }
    }
}
