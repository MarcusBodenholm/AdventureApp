using Adventure.Classes.Models;
using Adventure.Enums;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace Adventure.Classes.Logic
{
    public class GameLogic
    {
        private GameState GameState { get; set; } = new GameState();
        public string DecisionTree(string text)
        {
            //Add in new 
            Dictionary<Commands, Func<ParsedText, string>> methods = new()
            {
                {Commands.Drop, DropItem },
                {Commands.Inventory, ShowPlayerInventory},
                {Commands.Move, MoveCharacter },
                {Commands.Check, CheckDirection },
                {Commands.Examine, InspectX },
                {Commands.Inspect, InspectX },
                {Commands.Take, TakeItem},
                {Commands.Use, UseItemOnX }

            };
            ParsedText parsedText = Parser.ParseText(text.ToLower());
            MessageBox.Show($"{parsedText.Command}, {parsedText.Direction}, {parsedText.ItemOne}, {parsedText.ItemTwo}, {parsedText.Obstruction}, {parsedText.Remaining}");

            if (methods.ContainsKey(parsedText.Command))
            {
                return methods[parsedText.Command](parsedText);
            }
            return "Command was not recognized.";
        }
        private string InspectX(ParsedText parsed)
        {
            bool isRemainingZero = parsed.Remaining.Length == 0;
            if (parsed.ItemOne != Items.Unknown && isRemainingZero) return GameState.ExamineItem(parsed);
            if (parsed.Container != Containers.Unknown && isRemainingZero) return GameState.ExamineContainer(parsed);
            if (parsed.Direction != Directions.Unknown && isRemainingZero) 
            {
                (bool check, string output) = GameState.CheckDirection(parsed);
                return output;
            }
            if (isRemainingZero) return GameState.InspectLocation();
            if (parsed.Direction == Directions.Unknown) return "Not a valid direction";
            return "Command was not recognized.";
            
        }
        //private string ExamineX(ParsedText parsed)
        //{
        //    if (parsed.ItemOne != Items.Unknown) return GameState.ExamineItem(parsed);
        //    if (parsed.Container != Containers.Unknown) return GameState.ExamineContainer(parsed);
        //    return "Command was not recognized.";
        //}
        private string DropItem(ParsedText parsed)
        {
            return GameState.DropItem(parsed);
        }
        private string TakeItem(ParsedText parsed)
        {
            if (parsed.Container != Containers.Unknown && parsed.Remaining.Contains("from")
                && parsed.ItemOne != Items.Unknown && parsed.Remaining.Length == 4)
            {
                return GameState.PickUpItemFromContainer(parsed);
            }
            return GameState.PickUpItem(parsed);
        }
        //private string InspectDirection(ParsedText parsed)
        //{
        //    if (parsed.Remaining.Length > 2)
        //    {
        //        return "Command was not recognized.";
        //    }
        //    if (parsed.Direction == Directions.Unknown)
        //    {
        //        return "Not a valid direction.";
        //    }
        //    return GameState.InspectDirection(parsed);
        //}
        private string UseItemOnX(ParsedText parsed)
        {
            if (parsed.ItemOne == Items.Unknown &&
                (parsed.Obstruction == Obstructions.Unknown || parsed.ItemTwo == Items.Unknown)
                && !parsed.Remaining.Contains("on") && parsed.Remaining.Length != 2)
            {
                return "Command was not recognized.";
            }

            if (parsed.ItemTwo != Items.Unknown)
            {
                return GameState.UseItemOnItem(parsed);
            }
            if (parsed.Obstruction != Obstructions.Unknown)
            {
                return GameState.ClearObstruction(parsed);
            }
            return "Command was not recognized.";
        }
        private string CheckDirection(ParsedText parsed)
        {
            if (parsed.Direction == Directions.Unknown)
            {
                return "The direction needs to be North, South, East or West.";
            }
            (bool check, string output) = GameState.CheckDirection(parsed);
            return output;

        }
        //private string InspectLocation(ParsedText parsed)
        //{
        //    return GameState.InspectLocation();
        //}
        private string MoveCharacter(ParsedText parsed)
        {
            if (parsed.Direction == Directions.Unknown)
            {
                return "The direction needs to be North, South, East or West.";
            }
            return GameState.MoveToLocation(parsed);
        }
        private string ShowPlayerInventory(ParsedText parsed)
        {
            return GameState.DisplayInventory();
        }
        public GameState UpdateState()
        {
            return GameState;
        }
        public void HardCodeGameStart()
        {
            Location testLocation = new Location();
            testLocation.Name = "Kitchen";
            testLocation.Article = "A";
            testLocation.Description = "You are in a kitchen. To the north is a bedroom.";
            Item LocationItem = new Item();
            LocationItem.Name = "Corkscrew";
            LocationItem.ID = 1;
            LocationItem.Article = "A";
            LocationItem.Type = Items.Corkscrew;
            LocationItem.Description = "This is a Corkscrew.";
            LocationItem.UsableOn = Items.Bottle;

            Item extinguisher = new Item();
            extinguisher.Name = "Fire extinguisher";
            extinguisher.Article = "An";
            extinguisher.Type = Items.Extinguisher;
            Item shovel = new Item();
            shovel.Name = "Shovel";
            shovel.Description = "This is a shovel.";
            shovel.Article = "A";
            shovel.Type = Items.Shovel;

            Item SpecialItem = new Item();
            SpecialItem.Name = "Opened bottle";
            SpecialItem.ID = 3;
            SpecialItem.Article = "An";
            SpecialItem.Type = Items.OpenedBottle;
            SpecialItem.Description = "This is an opened bottle.";
            LocationItem.SpecialItem = SpecialItem;
            testLocation.Items.Add(LocationItem);
            testLocation.Items.Add(shovel);

            Item itemTwo = new Item();
            itemTwo.Name = "Bottle";
            itemTwo.Article = "A";
            itemTwo.ID = 2;
            itemTwo.Type = Items.Bottle;
            itemTwo.Description = "This is a bottle";


            Location secondL = new Location();
            secondL.Name = "Bedroom";
            secondL.Article = "A";
            secondL.Description = "You are in a bedroom. To the south is a kitchen.";
            secondL.Items.Add(itemTwo);

            Exit testExit = new Exit();
            testExit.Locations.Add(Directions.South, testLocation);
            testExit.Locations.Add(Directions.North, secondL);
            testLocation.Exits.Add(Directions.North, testExit);
            secondL.Exits.Add(Directions.South, testExit);
            GameState.SetStartingLocation(testLocation);
            Obstruction obstruction = new Obstruction();
            obstruction.Name = "Boulder";
            obstruction.Article = "A";
            obstruction.Type = Obstructions.Boulder;
            obstruction.ClearedBy = "Shovel";
            testExit.Obstruction = obstruction;

            Container testContainer = new();
            testContainer.Name = "Cupboard";
            testContainer.Article = "A";
            testContainer.Description = "This is a cupboard.";
            testContainer.Type = Containers.Cupboard;
            testLocation.Containers.Add(testContainer);

            Item key = new Item();
            key.Name = "Key";
            key.Article = "A";
            key.Description = "This is a key.";
            key.Type = Items.Key;
            testContainer.AddItem(key);

        }
        public string[] GameStart()
        {
            string[] output = new string[]
            {
                "You awake with no memory of where you are or how you got here",
                $"{GameState.InspectLocation()}"
            };
            return output;
        }
    }
}
