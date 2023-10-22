using AppLogic.Enums;

namespace AppLogic.Models
{
    public class Container : IInventory
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();
        public string Article { get; set; } = string.Empty;
        public bool Liftable { get; set; } = false;
        public Containers Type { get; set; } = Containers.Unknown;
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
        }
        public bool HasItem(Items itemType)
        {
            return Items.Any(item => item.Type == itemType);
        }
        public Item? GetItem(Items itemType)
        {
            return Items.Find(item => item.Type == itemType);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public string Inspect()
        {
            return $"{Description} {ListItems()}";
        }
        private string ListItems()
        {
            if (Items.Count == 0)
            {
                return $"The {Name.ToLower()} does not have any items.";
            }
            string output = $"The {Name.ToLower()} contains the following items: ";
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
