using AppLogic.Enums;

namespace AppLogic.Models
{
    public interface IInventory
    {
        public void RemoveItem(Item item);
        public void AddItem(Item item);
        public Item? GetItem(string itemType);
        public bool HasItem(string itemType);

    }
}
