namespace AppLogic.Logic
{
    public class Outcome
    {
        public string Message { get; set; } = string.Empty;
        public string CurrentLocation { get; set; } = string.Empty;
        public bool HasWon { get; set; } = false;
        public List<string> InventoryNames { get; set; } = new List<string>();
    }
}
