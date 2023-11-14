using AppLogic.Enums;
using System.Security.Cryptography;

namespace AppLogic.Models
{

    public class Location
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; } = false;
        public List<Container> Containers { get; set; } = new();
        public Dictionary<Direction, Exit> Exits { get; set; } = new();
        public List<Item> Items { get; set; } = new List<Item>();
        public bool HasEntered { get; set; } = false;
        public Event? Event { get; set; } = null;
        public List<NPC>? NPCs { get; set; } = null;
        public override string ToString()
        {
            return $"the {Name}".ToLower();
        }
        public string NameLower()
        {
            return Name.ToLower();
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public bool HasItem(string itemType)
        {
            return Items.Any(item => item.Type == itemType);
        }
        public Item? GetItem(string itemType)
        {
            return Items.Find(item => item.Type == itemType);
        }
        public Container? GetContainer(string containerType)
        {
            return Containers.Find(container => container.Type == containerType);
        }
        public void RemoveContainer(Container container)
        {
            Containers.Remove(container);
        }
        public void AddContainer(Container container)
        {
            Containers.Add(container);
        }
        public NPC? GetNPC(string handle)
        {
            if (NPCs == null) return null;
            foreach (NPC n in NPCs)
            {
                if (n.Type == handle) return n;
            }
            return null;
        }
        public string Inspect()
        {
            string output = Description;
            if (Items.Count == 0)
            {
                output += "\nThere are no items here.";
            }
            else
            {
                output += $"\nYou see the following items in the room: {ListItems()}.";
            }
            if (Containers.Count > 0)
            {
                string containerInfo = $"You see ";
                int count = 0;
                foreach (var container in Containers)
                {
                    if (count == 0)
                    {
                        containerInfo += container.ToString();
                    }
                    else if (count == Containers.Count-1)
                    {
                        containerInfo += $" & {container}";
                    }
                    else
                    {
                        containerInfo += $", {container}";
                    }
                    count++;
                }
                output += " \n" + containerInfo + ".";
            }
            if (NPCs != null && NPCs.Count > 0)
            {
                string NPCInfo = "\nYou also see the following people: ";
                int count = 0;
                foreach (NPC n in NPCs)
                {
                    if (count == 0)
                    {
                        NPCInfo += n.Name;
                    }
                    else if (count == NPCs.Count - 1)
                    {
                        NPCInfo += $" & {n.Name}";
                    }
                    else
                    {
                        NPCInfo += $", {n.Name}";
                    }
                    count++;
                }
                output += NPCInfo + ".";
            }
            return output;
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
                else if (count == Items.Count-1)
                {
                    items += $" & {item}";
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
