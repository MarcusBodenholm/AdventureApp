using Adventure.Enums;

namespace Adventure.Classes.Models
{
    public class Location
    {
        public string Name { get; set; } = string.Empty;
        public int ID { get; set; } = -1;
        public string Description { get; set; } = string.Empty;
        public List<Containers> Containers { get; set; } = new List<Containers>();
        public Dictionary<Directions, Exit> Exits { get; set; } = new Dictionary<Directions, Exit>();
        public string Article { get; set; }
        public bool IsEndPoint { get; set; } = false;
        public List<Item> Items { get; set; } = new List<Item>();
        public override string ToString()
        {
            return $"{Article.ToLower()} {Name}".ToLower();
        }
        public void RemoveItem(int id)
        {
            Items = Items.Where(item => item.ID != id).ToList();
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public string Inspect()
        {
            string output = Description;
            if (Containers.Count > 0)
            {
                string containerInfo = $"In the {Name.ToLower()} there's ";
                int count = 0;
                foreach (var container in Containers)
                {
                    if (count == 0)
                    {
                        containerInfo += container.ToString();
                    }
                    else if (count)
                    else
                    {
                        containerInfo += $", {}";
                    }
                    count++;
                }
            }
            return "";
        }
        public string ListItems()
        {
            string items = "";
            int count = 0;
            foreach (var item in Items)
            {
                if (count == 0)
                {
                    items += item.ToString();
                }
                else
                {
                    items += ", " + item.ToString();
                }
                count++;
            }
            return items;
        }

    }
}
