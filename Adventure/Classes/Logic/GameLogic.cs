using Adventure.Classes.Models;
using Adventure.Enums;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace Adventure.Classes.Logic
{
    public class GameLogic
    {
        public Character PC { get; set; } = new Character();
        public string Parser(string text)
        {
            Dictionary<Commands, Func<string, string>> methods = new Dictionary<Commands, Func<string, string>>()
            {
                {Commands.Take, PC.PickUpItem },
                {Commands.Drop, PC.DropItem },
                {Commands.Inventory, ShowPlayerInventory},
                {Commands.Move, MoveCharacter },
                {Commands.Check, CheckDirection },
                {Commands.Look, InspectLocation },
                {Commands.Examine, PC.ExamineItem }

            };
            string[] inputs = text.Split(" ");
            string secondInput = inputs.Length < 2 ? "" : inputs[1];

            Commands command = EnumParser.Command(inputs[0].ToLower());
            Obstructions obstruction = inputs.Length > 3 ? EnumParser.Obstruction(inputs[3].ToLower()) 
                                                         : Obstructions.Unknown;
            Items firstItem = inputs.Length > 1 ? EnumParser.Item(inputs[1].ToLower()) : Items.Unknown;
            Items secondItem = inputs.Length > 3 ? EnumParser.Item(inputs[3].ToLower()) : Items.Unknown;
            Directions direction = inputs.Length > 1 ? EnumParser.Direction(inputs[1].ToLower()) 
                                                       : Directions.Unknown;

            if (command == Commands.Use && obstruction != Obstructions.Unknown &&
                inputs.Length == 4 && inputs[2] == "on") return ClearObstruction(secondInput, inputs[3]);
            if (methods.ContainsKey(command))
            {
                return methods[command](secondInput);
            }
            if (command == Commands.Use && firstItem != Items.Unknown && secondItem != Items.Unknown && 
                inputs[2] == "on" && inputs.Length == 4)
            {
                string combined = $"{secondInput},{inputs[3]}";
                return PC.UseItemOnItem(combined);
            }
            if (command == Commands.Use && inputs[2] == "on" && inputs.Length == 4)
            {
                //Directions direction = EnumParser.Direction(inputs[3]);
                //if (direction == Directions.Unknown) return "Not a valid direction.";
                //return "";
            }
            if (command == Commands.Inspect && direction != Directions.Unknown && inputs.Length == 2)
            {
                return PC.InspectDirection(direction);
            }
            return "Command was not recognized";
        }
        public string CheckDirection(string input)
        {
            Directions direction = EnumParser.Direction(input);
            if (direction == Directions.Unknown)
            {
                return "The direction needs to be North, South, East or West";
            }
            (bool check, string output) = PC.CheckDirection(direction);
            return output;

        }
        public string InspectLocation(string input)
        {
            return PC.InspectLocation();
        }
        public string MoveCharacter(string input)
        {
            Directions direction = EnumParser.Direction(input);
            if (direction == Directions.Unknown)
            {
                return "The direction needs to be North, South, East or West";
            }
            return PC.MoveToLocation(direction);
        }
        public string ShowPlayerInventory(string input)
        {
            return PC.ShowItems();
        }
        public Character UpdateStatus()
        {
            return PC;
        }
        public string ClearObstruction(string input, string obstructionName)
        {
            return PC.ClearObstruction(input, obstructionName);
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
            LocationItem.Description = "This is a Corkscrew";
            LocationItem.UsableOn = "Bottle";

            Item extinguisher = new Item();
            extinguisher.Name = "Extinguisher";
            extinguisher.Article = "An";
            extinguisher.Type = Items.Extinguisher;
            Item shovel = new Item();
            shovel.Name = "Shovel";
            shovel.Article = "A";
            shovel.Type = Items.Shovel;

            Item SpecialItem = new Item();
            SpecialItem.Name = "Opened bottle";
            SpecialItem.ID = 3;
            SpecialItem.Article = "An";
            SpecialItem.Type = Items.OpenedBottle;
            SpecialItem.Description = "This is an opened bottle";
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
            PC.CurrentLocation = testLocation;
            Obstruction obstruction = new Obstruction();
            obstruction.Name = "Boulder";
            obstruction.Article = "A";
            obstruction.ClearedBy = "Shovel";
            testExit.Obstruction = obstruction;

        }
        public string[] GameStart()
        {
            string[] output = new string[]
            {
                "You awake with no memory of where you are or how you got here",
                $"{PC.InspectLocation()}"
            };
            return output;
        }
    }
}
