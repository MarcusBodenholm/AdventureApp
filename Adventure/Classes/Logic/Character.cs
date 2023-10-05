using Adventure.Enums;
using System.Collections.Specialized;
using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Character
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Location CurrentLocation { get; set; }
        public (bool, string) CheckDirection(Directions direction)
        {
            bool pathExists = CurrentLocation.Exits.ContainsKey(direction);
            if (pathExists == false)
            {
                return (false, $"There is no door to the {direction.ToString().ToLower()}");
            }

            bool hasObstruction = CurrentLocation.Exits[direction].Obstruction != null;
            if (hasObstruction)
            {
                Obstruction obstruction = CurrentLocation.Exits[direction].Obstruction;
                string output = $"{obstruction.Article} {obstruction.Name.ToLower()} blocks the exit.";
                return (false, output);
            }
            if (CurrentLocation.Exits[direction].IsLocked)
            {
                return (false, $"The door is locked");
            }
            return (true, $"The door is open and leads to {CurrentLocation.Exits[direction].Locations[direction].Name.ToLower()})");
        }
        public string MoveToLocation(Directions direction)
        {
            (bool check, string output) = CheckDirection(direction);
            if (check == false)
            {
                return output;
            }
            CurrentLocation = CurrentLocation.Exits[direction].Locations[direction];
            return $"You move to the {direction.ToString().ToLower()}. You are now in {CurrentLocation.Name.ToLower()}";
        }
        public void UseItem(string command)
        {
        }
        public string DropItem(string nameOfItem)
        {
            bool hasItem = Items.Any(item => item.Name.ToLower() == nameOfItem.ToLower());
            if (hasItem)
            {
                Item itemToDrop = Items.Find(item => item.Name.ToLower() == nameOfItem.ToLower());
                CurrentLocation.Items.Add(itemToDrop);
                Items.Remove(itemToDrop);
                return $"You drop {itemToDrop} on the ground";
            }
            return $"You do not have {nameOfItem}";
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
                return $"There is no {parsed.ItemOne} in the room";
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
        public string ClearObstruction(string itemInput, string obstructionName)
        {
            Item item = Items.Find(item => item.Name.ToLower() == itemInput);
            if (item == null)
            {
                return $"You do not have {itemInput}";
            }
            Exit? exit = null;
            Obstruction? obstruction = null;
            foreach (Exit value in CurrentLocation.Exits.Values)
            {
                if (value.Obstruction != null && value.Obstruction.Name.ToLower() == obstructionName.ToLower())
                {
                    exit = value;
                    obstruction = value.Obstruction;
                }
            }
            if (obstruction != null && exit != null && obstruction.ClearedBy.ToLower() == item.Name.ToLower())
            {
                exit.Obstruction = null;
                Items.Remove(item);
                return $"You use your {item.Name.ToLower()} to clear the {obstruction.Name.ToLower()}";
            }
            if (item.Name.ToLower() != obstruction.ClearedBy.ToLower())
            {
                return $"You cannot clear a {obstructionName} with {item.Name}";
            }
            return "Something went wrong";

        }
        public string UseItemOnItem(string items)
        {
            bool output = false;
            string message = "";
            string[] splitItems = items.Split(',');
            string firstItemName = splitItems[0];
            string secondItemName = splitItems[1];
            Item itemOne = Items.Find(item => item.Name.ToLower() == firstItemName.ToLower());
            if (itemOne == null) return $"You do not have {firstItemName}";
            Item itemTwo = Items.Find(item => item.Name.ToLower() == secondItemName.ToLower());
            if (itemTwo == null) return $"You do not have {secondItemName}";

            if (itemOne.UsableOn != itemTwo.Name || itemOne.SpecialItem == null)
            {
                return $"Nothing happens when you use {itemOne.Name.ToLower()} on {itemTwo.Name.ToLower()}";
            }
            Item newItem = itemOne.SpecialItem;
            Items.Add(newItem);
            Items.Remove(itemOne);
            Items.Remove(itemTwo);
            message = $"You use {itemOne.Name.ToLower()} on {itemTwo.Name.ToLower()}, and gain {newItem}";
            return message;
        }
        public string ExamineItem(string itemName)
        {
            string message = "";
            Item InspectedItem = Items.Find(item => item.Name.ToLower() == itemName.ToLower());
            if (itemName == "") return "You need to specify an item to examine.";
            if (InspectedItem == null)
            {
                InspectedItem = CurrentLocation.Items.Find(item => item.Name.ToLower() == itemName.ToLower());
                if (InspectedItem == null)
                {
                    return $"There's no {itemName} in neither your inventory nor the {CurrentLocation.Name.ToLower()}";
                }
                return InspectedItem.Inspect();

            }
            message = InspectedItem.Inspect();
            return message;
        }
        public string InspectDirection(Directions direction)
        {
            (bool check, string message) = CheckDirection(direction);
            if (message == $"There is no path to the {direction}") return "Not a valid direction.";
            message = CurrentLocation.Exits[direction].Inspect();
            return message;
        }
        public string UseItemInDirection(string itemName, Directions direction)
        {
            //Gör klart
            return "";
        }
    }
}
