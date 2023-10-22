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
            LoadItemsFromJson();
            LoadAllContainers();
            LoadAllObstructions();
            LoadAllExits();
            LoadAllEvents();
            LoadLocationsFromJson();
        }
        private static void LoadItemsFromJson()
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
        private static void LoadLocationsFromJson()
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
        private static void LoadAllExits()
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
        private static void LoadAllContainers()
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
        private static void LoadAllObstructions()
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
        private static void LoadAllEvents()
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
    }
}
