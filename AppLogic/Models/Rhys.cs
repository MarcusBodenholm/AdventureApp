namespace AppLogic.Models
{
    public class Rhys : NPC
    {
        public Rhys()
        {
            Name = "Rhys";
            Description = "An elderly man with a long graying beard, dressed in a purple suit.";
            Greeting = "Hello there, friend. My name is Rhys. I am glad to see you up and about.";
            Farewell = "It's been a pleasure talking to you. I wish you luck on your journey, and may we meet again!";
            Type = "rhys";
            ItemID = 10;
            GiftItemID = 25;
            Conversations = new()
            {
                { "who are you", "I am but an old man in search of items in beautiful purple." },
                {"what are you doing", "For a very long time, all I have done is wait." },
                {"what are you waiting for", "For something to happen. I have been here a long time." },
                {"why are you waiting", "I've got nothing better to do." },
                { "where am i", "Unfortunately I do not know where we are. A house, that much I know. I have been trapped here for a very long time." },
                { "where", "Unfortunately I do not know where we are. A house, that much I know. I have been trapped here for a very long time." },
                { "how do i get out", "There is a security door in the basement that leads out, probably. But you need a key. I have one piece of it that I can give you, if you give me what I want." },
                { "can you help me", "If you give me what I want, I am certain that I can be of assistance." },
                { "help me", "If you give me what I want, I am certain that I can be of assistance." },
                { "what do you want", "I once had a basket with the nicest purple things: A carving of my favorite animal, and a bouquet of flowers. I want one of those." },
                { "what is your favorite animal", "A goat of course. My father once gave me one, and he was my best friend." },
                { "how are you here", "I could ask you the same thing. I woke up here one day, a long time ago." },
                {"what are you", "What do you mean? I am a person, same as you." },
                {"how old are you", "I can't quite remember. Very old is my guess." },
                { "when are we", "The current year, I believe."},
                {"what is your favorite color", "Blue. No puuuuuurpppleeeeee." },
                {"what's your favorite color", "Blue. No puuuuuurpppleeeeee." },
                {"what is your favourite colour", "Blue. No puuuuuurpppleeeeee." },
                {"what's your favourite colour", "Blue. No puuuuuurpppleeeeee." },
                {"will you help me leave", "If you give me what I want, I am certain that I can be of assistance." },
                {"how did you get here", "I woke up here one day. For a while I tried to escape, but that was a long time ago now." },
                {"did you kidnap me", "Heavens no. I would do no such thing. No, I am afraid we were both put here, somehow." },
                {"did you take me here", "Heavens no. I would do no such thing. No, I am afraid we were both put here, somehow." },
            };

        }
    }
}
