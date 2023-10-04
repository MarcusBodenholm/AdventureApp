namespace Adventure.Classes.Models
{
    public class Container
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Article { get; set; }
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name.ToLower()}";
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
                    output += item.ToString();
                }
                else
                {
                    output += $", {item}";
                }
            }
            return output;
        }
    }
}
