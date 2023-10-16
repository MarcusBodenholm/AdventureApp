using AppLogic.Enums;

namespace AppLogic.Models
{
    public interface IInventory
    {
        public void RemoveItem(Item item);
        public void AddItem(Item item);
        public Item? GetItem(Items itemType);
        public bool HasItem(Items itemType);

    }
}
