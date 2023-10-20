﻿namespace Adventure.Classes.Data
{
    public class JsonItem
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UsableOn { get; set; } = -1;
        public string Type { get; set; } = string.Empty;
        public int SpecialItem { get; set; } = -1;
        public string Article { get; set; } = string.Empty;
        public bool Persistent { get; set; } = false;

    }
}