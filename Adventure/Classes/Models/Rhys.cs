namespace Adventure.Classes.Models
{
    public class Rhys : NPC
    {
        public Rhys()
        {
            Name = "Rhys";
            Description = "An elderly man with a long graying beard, dressed in a purple suit.";
            Greeting = "Hello there, young one. My name is Rhys, how can I help you?";
            Farewell = "It's been a pleasure talking to you. I wish you luck on your journey, and may we meet again!";
            Type = Enums.NPCs.Rhys;
            ItemID = 10;
            GiftItemID = 25;
            Conversations = new()
            {
                { "who are you", "I am but an old man in search of items in the finest imperial color." },
                { "where am i", "Unfortunately I do not know where we are. A house, that much I know." },
                { "how do i get out", "There is a security door in the basement that leads out. But you need a key." },
                { "can you help me", "If you give me what I want, I am certain that I can be of assistance." },
                { "help me", "If you give me what I want, I am certain that I can be of assistance." },
                { "what do you want", "I have always wanted basket with the nicest purple things: A carving of my favorite animal, and a bouquet of flowers." },
                { "what is your favorite animal", "A goat of course. My father once gave me one, and he was my best friend." },
                { "how are you here", "I could ask you the same thing." },
                {"what are you", "What do you mean? I am a person, same as you." },
                {"how old are you", "I can't quite remember. Very old is my guess." },
                { "when are we", "The current year, I believe."},
                {"what is your favorite color", "Blue. No puuuuuurpppleeeeee." },
                {"what's your favorite color", "Blue. No puuuuuurpppleeeeee." },
                {"what is your favourite colour", "Blue. No puuuuuurpppleeeeee." },
                {"what's your favourite colour", "Blue. No puuuuuurpppleeeeee." },
                {"will you help me leave", "If you give me what I want, I am certain that I can be of assistance." }
            };

        }
    }
}
