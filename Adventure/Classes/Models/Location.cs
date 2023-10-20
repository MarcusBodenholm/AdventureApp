﻿using Adventure.Enums;

namespace Adventure.Classes.Models
{

    public class Location : IInventory
    {
        public string Name { get; set; } = string.Empty;
        public int ID { get; set; } = -1;
        public string Description { get; set; } = string.Empty;
        public List<Container> Containers { get; set; } = new();
        public Dictionary<Directions, Exit> Exits { get; set; } = new();
        public string Article { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; } = false;
        public List<Item> Items { get; set; } = new List<Item>();
        public bool HasNotEntered { get; set; } = true;
        public Event? Event { get; set; } = null;
        public bool NPC { get; set; } = false;
        public override string ToString()
        {
            return $"the {Name}".ToLower();
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public bool HasItem(Items itemType)
        {
            return Items.Any(item => item.Type == itemType);
        }
        public Item? GetItem(Items itemType)
        {
            return Items.Find(item => item.Type == itemType);
        }
        public Container? GetContainer(Containers containerType)
        {
            return Containers.Find(container => container.Type == containerType);
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