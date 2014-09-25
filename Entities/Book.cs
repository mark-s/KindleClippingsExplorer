using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClippingsExplorer.Entities
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }

        private Book(string title, string author)
        {
            Author = author;
            Title = title;
        }

        static readonly Regex _titleRegex = new Regex(@".*\((.*)\)", RegexOptions.Compiled);

        public static Book GetBookFromString(string rawTextLine)
        {
            var matched = _titleRegex.Match(rawTextLine);

            if (matched.Success == false)
                return new Book("Failed", "Unknown");
            else
                return new Book(matched.Groups[1].Value, matched.Groups[2].Value);
        }

    }
}
