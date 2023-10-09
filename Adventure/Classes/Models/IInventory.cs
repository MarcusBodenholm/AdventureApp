using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public interface IInventory
    {
        public void RemoveItem(Item item);
        public void AddItem(Item item);
        public Item? GetItem(Items itemType);
        public bool HasItem(Items itemType);

    }
}
