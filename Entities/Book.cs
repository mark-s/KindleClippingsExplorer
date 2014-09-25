using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ClippingsExplorer.Entities
{
    [DebuggerDisplay("{Title} {Author}")]
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }

        private Book(string title, string author)
        {
            Author = author;
            Title = title;
        }

        static readonly Regex _titleRegex = new Regex(@"(.*)\s\(", RegexOptions.Compiled);
        static readonly Regex _authorRegex = new Regex(@".*\s\((.*)\)", RegexOptions.Compiled);

        public static Book GetBookFromString(string rawTextLine)
        {
            var title = _titleRegex.Match(rawTextLine);
            var author = _authorRegex.Match(rawTextLine);

            return new Book(title.Groups[1].Value, author.Groups[1].Value);
        }

    }
}
