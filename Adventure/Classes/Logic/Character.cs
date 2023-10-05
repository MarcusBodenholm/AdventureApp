using Adventure.Enums;
using System.Collections.Specialized;
using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class State
    {
        public Character PC { get; set; }
        public Location CurrentLocation { get; set; }
        public (bool, string) CheckDirection(Parsed parsed)
        {
            bool pathExists = CurrentLocation.Exits.ContainsKey(parsed.Direction);
            if (pathExists == false)
            {
                return (false, $"There is no door to the {parsed.DirectionText.ToLower()}");
            }

            bool hasObstruction = CurrentLocation.Exits[parsed.Direction].Obstruction != null;
            if (hasObstruction)
            {
                Obstruction obstruction = CurrentLocation.Exits[parsed.Direction].Obstruction;
                string output = $"{obstruction.Article} {obstruction.Name.ToLower()} blocks the exit.";
                return (false, output);
            }
            if (CurrentLocation.Exits[parsed.Direction].IsLocked)
            {
                return (false, $"The door is locked");
            }
            return (true, $"The door is open and leads to {CurrentLocation.Exits[parsed.Direction].Locations[parsed.Direction].Name.ToLower()})");
        }
        public string MoveToLocation(Parsed parsed)
        {
            (bool check, string output) = CheckDirection(parsed);
            if (check == false)
            {
                return output;
            }
            CurrentLocation = CurrentLocation.Exits[parsed.Direction].Locations[parsed.Direction];
            return $"You move to the {parsed.DirectionText.ToLower()}. You are now in {CurrentLocation.Name.ToLower()}";
        }


    }

    public class Character
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Location CurrentLocation { get; set; }
        public (bool, string) CheckDirection(Parsed parsed)
        {
            bool pathExists = CurrentLocation.Exits.ContainsKey(parsed.Direction);
            if (pathExists == false)
            {
                return (false, $"There is no door to the {parsed.DirectionText.ToLower()}");
            }

            bool hasObstruction = CurrentLocation.Exits[parsed.Direction].Obstruction != null;
            if (hasObstruction)
            {
                Obstruction obstruction = CurrentLocation.Exits[parsed.Direction].Obstruction;
                string output = $"{obstruction.Article} {obstruction.Name.ToLower()} blocks the exit.";
                return (false, output);
            }
            if (CurrentLocation.Exits[parsed.Direction].IsLocked)
            {
                return (false, $"The door is locked");
            }
            return (true, $"The door is open and leads to {CurrentLocation.Exits[parsed.Direction].Locations[parsed.Direction].Name.ToLower()})");
        }
        public string MoveToLocation(Parsed parsed)
        {
            (bool check, string output) = CheckDirection(parsed);
            if (check == false)
            {
                return output;
            }
            CurrentLocation = CurrentLocation.Exits[parsed.Direction].Locations[parsed.Direction];
            return $"You move to the {parsed.DirectionText.ToLower()}. You are now in {CurrentLocation.Name.ToLower()}";
        }
        public string DropItem(Parsed parsed)
        {
            bool hasItem = Items.Any(item => item.Type == parsed.ItemOne);
            if (hasItem)
            {
                Item itemToDrop = Items.Find(item => item.Type == parsed.ItemOne);
                CurrentLocation.Items.Add(itemToDrop);
                Items.Remove(itemToDrop);
                return $"You drop {itemToDrop} on the ground";
            }
            return $"You do not have {parsed.ItemOneText}";
        }
        public string PickUpItem(Parsed parsed)
        {
            if (parsed.ItemOne == Enums.Items.Unknown) return "You need to specify an item";
            bool roomHasItem = CurrentLocation.Items.Any(item => item.Type == parsed.ItemOne);
            if (roomHasItem)
            {
                Item itemToPickup = CurrentLocation.Items.Find(item => item.Type == parsed.ItemOne);
                Items.Add(itemToPickup);
                CurrentLocation.Items.Remove(itemToPickup);
                return $"You pick up {itemToPickup}";
            }
            else
            {
                return $"There is no {parsed.ItemOneText} in the room";
            }
        }
        public string ShowItems()
        {
            string output = "";
            int count = 0;
            foreach (var item in Items)
            {
                if (count == 0)
                {
                    output += item.Name;
                }
                else
                {
                    output += ", " + item.Name;
                }
                count++;
            }
            return output;
        }
        public string InspectLocation()
        {
            string output = "";
            if (CurrentLocation.Items.Count == 0)
            {
                return $"{CurrentLocation.Description}. " +
                       $"There are no items here.";
            }
            else
            {
                output += CurrentLocation.Description;
                output += $" You see the following items in the room: {CurrentLocation.ListItems()}.";
            }
            return output;
        }
        public string ClearObstruction(Parsed parsed)
        {
            Item item = Items.Find(item => item.Type == parsed.ItemOne);
            if (item == null)
            {
                return $"You do not have {parsed.ItemOneText}";
            }
            Exit? exit = null;
            Obstruction? obstruction = null;
            foreach (Exit value in CurrentLocation.Exits.Values)
            {
                if (value.Obstruction != null && value.Obstruction.Type == parsed.Obstruction)
                {
                    exit = value;
                    obstruction = value.Obstruction;
                }
            }
            if (obstruction == null)
            {
                return $"There is no {parsed.ObstructionText} in the {CurrentLocation.Name.ToLower()}";
            }
            if (obstruction != null && exit != null && obstruction.ClearedBy.ToLower() == item.Name.ToLower())
            {
                exit.Obstruction = null;
                Items.Remove(item);
                return $"You use your {item.Name.ToLower()} to clear the {obstruction.Name.ToLower()}";
            }
            if (item.Name.ToLower() != obstruction.ClearedBy.ToLower())
            {
                return $"You cannot clear a {parsed.ObstructionText} with {item.Name}";
            }
            return "Something went wrong";

        }
        public string UseItemOnItem(Parsed parsed)
        {
            Item itemOne = Items.Find(item => item.Type == parsed.ItemOne);
            if (itemOne == null) return $"You do not have {parsed.ItemOneText}";
            Item itemTwo = Items.Find(item => item.Type == parsed.ItemTwo);
            if (itemTwo == null) return $"You do not have {parsed.ItemTwoText}";

            if (itemOne.UsableOn != itemTwo.Name || itemOne.SpecialItem == null)
            {
                return $"Nothing happens when you use {parsed.ItemOneText} on {parsed.ItemTwoText}";
            }
            Item newItem = itemOne.SpecialItem;
            Items.Add(newItem);
            Items.Remove(itemOne);
            Items.Remove(itemTwo);
            return $"You use {parsed.ItemOneText} on {parsed.ItemTwoText}, and gain {newItem}";
        }
        public string ExamineItem(Parsed parsed)
        {
            string message = "";
            Item InspectedItem = Items.Find(item => item.Type == parsed.ItemOne);
            if (parsed.ItemOne == Enums.Items.Unknown) return "You need to specify an item to examine.";
            if (InspectedItem == null)
            {
                InspectedItem = CurrentLocation.Items.Find(item => item.Type == parsed.ItemOne);
                if (InspectedItem == null)
                {
                    return $"There's no {parsed.ItemOneText} in neither your inventory nor the {CurrentLocation.Name.ToLower()}";
                }
                return InspectedItem.Inspect();

            }
            return InspectedItem.Inspect();
        }
        public string InspectDirection(Parsed parsed)
        {
            (bool check, string message) = CheckDirection(parsed);
            if (message == $"There is no path to the {parsed.DirectionText}") return "Not a valid direction.";
            message = CurrentLocation.Exits[parsed.Direction].Inspect();
            return message;
        }
        public string UseItemInDirection(string itemName, Directions direction)
        {
            //Gör klart
            return "";
        }
    }
}
