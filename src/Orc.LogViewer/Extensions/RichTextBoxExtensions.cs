namespace Orc.LogViewer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Documents;

    public static class RichTextBoxExtensions
    {
        public static string GetInlineText(this RichTextBox richTextBox)
        {
            ArgumentNullException.ThrowIfNull(richTextBox);

            var sb = new StringBuilder();

            foreach (var block in richTextBox.Document.Blocks.OfType<Paragraph>())
            {
                foreach (var inline in block.Inlines.OfType<Run>())
                {
                    sb.AppendLine(inline.Text);
                }
            }

            return sb.ToString();
        }
    }
}
