using AppLogic.Models;
using AppLogic.DataAccess;
using System.Collections;

namespace AppLogic.Logic
{
    public class GameState
    {
        private Character PC { get; set; } = new Character();
        private Location CurrentLocation { get; set; } = new Location();
        private NPC NPC { get; set; } = new Rhys();
        public bool ConversationMode { get; set; } = false;
        public bool IsWon { get; set; } = false;
        public GameState(Character pc)
        {
            PC = pc;
            Location? location = Data.GetLocation(PC.SaveLocationID);
            if (location == null) throw new ArgumentNullException();
            CurrentLocation = location;
        }
        public string StartTalkingToNPC()
        {
            if (CurrentLocation.NPC != true) return "There is no one in this room.";
            ConversationMode = true;
            return $"{NPC.Name}: {NPC.Greeting} \nYou are now in conversation mode with {NPC.Name}. To stop write 'stop' or 'stop talking'.";
        }
        public string StopTalkingToNPC()
        {
            ConversationMode = false;
            return $"{NPC.Name}: {NPC.Farewell}\nYou are no longer in conversation mode with {NPC.Name}";
        }
        public string TalkToNPC(string input)
        {
            string text = input.ToLower();
            foreach (string topic in NPC.Conversations.Keys)
            {
                if (text.Contains(topic))
                {
                    return $"{NPC.Name}: {NPC.Conversations[topic]}";
                }
            }
            return $"{NPC.Name}: Sadly I have no answers to that.";
        }
        public string GiftNPC(ParsedText parsed)
        {
            Item? item = PC.GetItem(parsed.ItemOne);
            if (item == null) return $"You do not have {parsed.ItemOneText}";
            (string message, int itemID) = NPC.ReceiveGift(item.ID);
            Item? giftedItem = Data.GetItem(itemID);
            if (giftedItem == null) return $"Something went wrong with {itemID}.";
            PC.RemoveItem(item);
            PC.AddItem(giftedItem);
            return message;
        }
        public (bool, string) CheckDirection(ParsedText parsed)
        {
            bool pathExists = CurrentLocation.Exits.ContainsKey(parsed.Direction);
            if (pathExists == false)
            {
                return (false, $"There is no door to the {parsed.DirectionText.ToLower()}.");
            }
            Obstruction? obstruction = CurrentLocation.Exits[parsed.Direction].Obstruction;
            if (obstruction != null)
            {
                string output = $"{obstruction.Article} {obstruction.Name.ToLower()} blocks the door.";
                return (false, output);
            }
            if (CurrentLocation.Exits[parsed.Direction].IsLocked)
            {
                return (false, $"The door is locked.");
            }
            return (true, CurrentLocation.Exits[parsed.Direction].Inspect(parsed.Direction));
        }
        public string MoveToLocation(ParsedText parsed)
        {
            (bool check, string output) = CheckDirection(parsed);
            if (check == false)
            {
                return output;
            }
            Exit? exit = CurrentLocation.Exits[parsed.Direction];
            Location? newLocation = DataAccess.Data.GetLocation(CurrentLocation.Exits[parsed.Direction].Locations[parsed.Direction]);
            if (newLocation == null) return "Something went wrong.";
            if (newLocation.IsEndPoint) IsWon = true;
            CurrentLocation = newLocation;
            if (!CurrentLocation.HasEntered && CurrentLocation.Event != null)
            {
                Event? e = CurrentLocation.Event;
                if (e != null)
                {
                    if (e.Obstruction == null) return "Something went wrong";
                    int obstructId = (int)e.Obstruction;
                    CurrentLocation.HasEntered = true;
                    CurrentLocation.Exits[e.Direction].Obstruction = Data.GetObstruction(obstructId);
                    return $"As you enter {CurrentLocation}, to the {e.Direction.ToString().ToLower()} {e.EventText}\n{InspectLocation()}";
                }
            }
            CurrentLocation.HasEntered = true;
            string exitMessage = exit.Description == "door" ? $"You go through door to the {parsed.DirectionText.ToLower()}"
                                                            : $"You take the stairs to the {parsed.DirectionText.ToLower()}";
            return $"{exitMessage}. You are now in {CurrentLocation}. \n{InspectLocation()}";
        }
        public string DropItem(ParsedText parsed)
        {
            Container? CarryingContainer = PC.GetContainer();
            if (CarryingContainer != null) return $"You must drop the {CarryingContainer.Name.ToLower()} first.";
            Item? itemToDrop = PC.GetItem(parsed.ItemOne);
            if (itemToDrop != null)
            {
                CurrentLocation.Items.Add(itemToDrop);
                PC.Items.Remove(itemToDrop);
                return $"You drop the {itemToDrop.Name.ToLower()} on the ground.";
            }
            return $"You do not have {parsed.ItemOneText}.";
        }
        public string InspectItemInContainer(ParsedText parsed)
        {
            Container? container = CurrentLocation.GetContainer(parsed.Container);
            if (container == null)
            {
                return $"There is no {parsed.ContainerText} in the {CurrentLocation.NameLower()}.";
            }
            Item? item = container.GetItem(parsed.ItemOne);
            if (item == null)
            {
                return $"There is no {parsed.ItemOneText} in the {container.Name.ToLower()}.";
            }
            return item.Inspect();
        }
        public string UseItemOnItem(ParsedText parsed)
        {
            Container? CarryingContainer = PC.GetContainer();
            if (CarryingContainer != null) return $"You must drop the {CarryingContainer.Name.ToLower()} first.";
            Item? itemOne = PC.GetItem(parsed.ItemOne);
            if (itemOne == null) return $"You do not have {parsed.ItemOneText}.";
            Item? itemTwo = PC.GetItem(parsed.ItemTwo);
            if (itemTwo == null) return $"You do not have {parsed.ItemTwoText}.";

            if (itemOne.UsableOn != itemTwo.ID || itemOne.SpecialItem == -1)
            {
                return $"Nothing happens when you use {parsed.ItemOneText} on {parsed.ItemTwoText}.";
            }
            Item? newItem = Data.GetItem(itemOne.SpecialItem);
            if (newItem == null) return "Something went wrong.";
            PC.AddItem(newItem);
            PC.RemoveItem(itemOne);
            PC.RemoveItem(itemTwo);
            return $"You use {parsed.ItemOneText} on {parsed.ItemTwoText}, and gain {newItem}.";
        }
        public string PickUpItem(ParsedText parsed)
        {
            Container? CarryingContainer = PC.GetContainer();
            if (CarryingContainer != null) return $"You must drop the {CarryingContainer.Name.ToLower()} first.";
            if (parsed.ItemOne == string.Empty) return "You need to specify an item.";
            Item? itemToPickup = CurrentLocation.GetItem(parsed.ItemOne);
            if (itemToPickup != null)
            {
                PC.AddItem(itemToPickup);
                CurrentLocation.RemoveItem(itemToPickup);
                return $"You pick up the {itemToPickup.Name.ToLower()}.";
            }
            else
            {
                return $"There is no {parsed.ItemOneText} in the room.";
            }
        }
        public string PickUpItemFromContainer(ParsedText parsed)
        {
            Container? CarryingContainer = PC.GetContainer();
            if (CarryingContainer != null) return $"You must drop the {CarryingContainer.Name.ToLower()} first.";
            Container? container = CurrentLocation.GetContainer(parsed.Container);
            if (container == null) return $"There is no {parsed.ContainerText} in {CurrentLocation.NameLower()}.";
            Item? itemToPickUp = container.GetItem(parsed.ItemOne);
            if (itemToPickUp == null) return $"There is no {parsed.ItemOneText} in the {parsed.ContainerText}.";
            PC.AddItem(itemToPickUp);
            container.RemoveItem(itemToPickUp);
            return $"You pick up the {itemToPickUp.Name.ToLower()} from the {parsed.ContainerText}.";
        }
        public string PutItemInContainer(ParsedText parsed)
        {
            Container? CarryingContainer = PC.GetContainer();
            if (CarryingContainer != null) return $"You must drop the {CarryingContainer.Name.ToLower()} first.";
            Container? container = CurrentLocation.GetContainer(parsed.Container);
            if (container == null) return $"There is no {parsed.ContainerText} in {CurrentLocation.NameLower()}.";
            Item? ItemToPut = PC.GetItem(parsed.ItemOne);
            if (ItemToPut == null) return $"There is no {parsed.ItemOneText} in the {parsed.ContainerText}.";
            PC.RemoveItem(ItemToPut);
            container.AddItem(ItemToPut);
            return $"You have placed the {ItemToPut.Name.ToLower()} in the {parsed.ContainerText}.";
        }
        public string TakeContainer(ParsedText parsed)
        {
            Container? CarryingContainer = PC.GetContainer();
            if (CarryingContainer != null) return $"You must drop the {CarryingContainer.Name.ToLower()} first.";
            Container? container = CurrentLocation.GetContainer(parsed.Container);
            if (container == null) return $"There is no {parsed.ContainerText} in {CurrentLocation.NameLower()}.";
            if (container.Liftable == false) return $"The {parsed.ContainerText} is too heavy and cumbersome to take.";
            PC.TakeContainer(container);
            CurrentLocation.RemoveContainer(container);
            return $"You pick up the {parsed.ContainerText} from the {CurrentLocation.NameLower()}. Until you drop it, you are limited in what you can do.";
        }
        public string DropContainer(ParsedText parsed)
        {
            Container? container = PC.GetContainer();
            if (container == null || parsed.Container == string.Empty) return $"You are not carrying {parsed.ContainerText}.";
            CurrentLocation.AddContainer(container);
            PC.RemoveContainer();
            return $"You drop the {parsed.ContainerText} in {CurrentLocation.NameLower()}";

        }
        public string ExamineItem(ParsedText parsed)
        {
            Item? InspectedItem = PC.GetItem(parsed.ItemOne);
            if (parsed.ItemOne == string.Empty) return "You need to specify an item to examine.";
            if (InspectedItem == null)
            {
                InspectedItem = CurrentLocation.GetItem(parsed.ItemOne);
                if (InspectedItem != null)
                {
                    return InspectedItem.Inspect();
                }

            }
            if (InspectedItem == null && CurrentLocation.Containers.Count > 0)
            {
                foreach (var container in CurrentLocation.Containers)
                {
                    InspectedItem = container.GetItem(parsed.ItemOne);
                    if (InspectedItem != null) return InspectedItem.Inspect();
                }
                return $"There's no {parsed.ItemOneText} in neither your inventory nor the {CurrentLocation.NameLower()}.";
            }
            return $"There's no {parsed.ItemOneText} in neither your inventory nor the {CurrentLocation.NameLower()}.";
        }
        public string ExamineContainer(ParsedText parsed)
        {
            Container? examinedContainer = CurrentLocation.GetContainer(parsed.Container);
            if (examinedContainer == null) return $"There is no {parsed.ContainerText} in {CurrentLocation.NameLower()}.";
            return examinedContainer.Inspect();
        }
        public string ClearObstruction(ParsedText parsed)
        {
            if (PC.CarryingContainer != null) return $"You must drop the {PC.CarryingContainer.Name.ToLower()} first.";
            Item? item = PC.GetItem(parsed.ItemOne);
            if (item == null)
            {
                return $"You do not have {parsed.ItemOneText}.";
            }
            Exit? exit = null;
            Obstruction? obstruction = null;
            foreach (Exit value in CurrentLocation.Exits.Values)
            {
                if (value.Obstruction != null && value.Obstruction.Type == parsed.Obstruction)
                {
                    exit = value;
                    obstruction = value.Obstruction;
                    break;
                }
            }
            if (obstruction == null)
            {
                return $"There is no {parsed.ObstructionText} in the {CurrentLocation.NameLower()}.";
            }
            if (obstruction != null && exit != null && obstruction.ClearedBy == item.ID)
            {
                exit.Obstruction = null;
                if (item.Persistent == false)
                {
                    PC.Items.Remove(item);
                }
                string output = $"You use your {item.Name.ToLower()} to clear the {obstruction.Name.ToLower()}.";
                output += item.Persistent == false ? $"\nThe {item.Name.ToLower()} was lost in the process." : "";
                return output;
                       
            }
            if (item.ID != obstruction.ClearedBy)
            {
                return $"You cannot clear a {parsed.ObstructionText} with {item.Name}.";
            }
            return "Something went wrong";

        }
        public string InspectLocation()
        {
            return CurrentLocation.Inspect();
        }
        public string DisplayInventory()
        {
            return PC.DisplayInventory();
        }
        public List<string> GetPlayerItems()
        {
            return PC.Items.Select(item => item.Name).ToList();
        }
        public string GetCurrentLocationInfo()
        {
            return CurrentLocation.Name;
        }
        public string UnlockDoor(ParsedText parsed)
        {
            if (PC.CarryingContainer != null) return $"You must drop the {PC.CarryingContainer.Name.ToLower()} first.";
            Item? item = PC.GetItem(parsed.ItemOne);
            if (item == null) return $"You do not have {parsed.ItemOneText}.";
            if (!CurrentLocation.Exits.ContainsKey(parsed.Direction)) return $"There is no door to the {parsed.Direction.ToString().ToLower()}";
            Exit? exit = CurrentLocation.Exits[parsed.Direction];
            if (exit == null) return $"There is no door to the {parsed.Direction.ToString().ToLower()}";
            if (exit.IsLocked == false) return "The door is not locked.";
            if (exit.UnlockedBy != item.ID) return $"The {parsed.ItemOneText} cannot unlock this door.";
            if (exit.Obstruction != null)
            {
                return $"{exit.Obstruction.Article} {exit.Obstruction.Name.ToLower()} blocks the door."; ;
            }
            string output = exit.Unlock(item);
            PC.RemoveItem(item);
            return output;
        }
        public Character GetCharacter()
        {
            PC.SaveLocationID = CurrentLocation.ID;
            return PC;
        }
    }
}
