using AppLogic.Enums;
using System.Collections.Specialized;

namespace AppLogic.Models
{

    public class Character
    {
        public string Name { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();
        public Container? CarryingContainer { get; set; } = null;
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        public bool HasItem(string itemType)
        {
            return Items.Any(item => item.Type == itemType);
        }
        public Item? GetItem(string itemType)
        {
            return Items.Find(item => item.Type == itemType);
        }
        public Container? GetContainer()
        {
            return CarryingContainer;
        }
        public void TakeContainer(Container container)
        {
            CarryingContainer = container;
        }
        public void RemoveContainer()
        {
            CarryingContainer = null;
        }
        public string DisplayInventory()
        {
            if (Items.Count == 0) return "You have no items.";
            string output = "You have the following items: ";
            int count = 0;
            foreach (var item in Items)
            {
                if (count == 0)
                {
                    output += $"{item.Article} {item.Name.ToLower()}{(Items.Count == 0 ? "." : "")}";
                }
                else if (count == Items.Count - 1)
                {
                    output += $" & {item}.";
                }

                else
                {
                    output += ", " + item.ToString();
                }
                count++;
            }
            return output;
        }
    }
}
