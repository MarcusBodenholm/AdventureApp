namespace Adventure.Classes.Extensions
{
    public static class TextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool newLine)
        {
            string output = newLine ? "\n" + text : text;
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(output);
            box.SelectionStart = box.TextLength;
            box.ScrollToCaret();
        }
    }
}
