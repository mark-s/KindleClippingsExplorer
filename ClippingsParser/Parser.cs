using System;
using System.Collections.Generic;
using ClippingsExplorer.Entities;

namespace ClippingsExplorer.ClippingsParser
{
    public class Parser : IParser
    {


        public List<Clipping> ParseClippings(IList<string> itemsStrings)
        {
            if ((itemsStrings.Count-1) % 3 != 0)
                throw new FormatException("File in invalid!");

            var toReturn = new List<Clipping>();

            for (int i = 0; i < itemsStrings.Count-1; i += 3)
            {

                var book = Book.GetBookFromString(itemsStrings[i]);
                var highlight = HighlightItem.GetItemFromString(itemsStrings[i + 1], itemsStrings[i + 2]);

                toReturn.Add(new Clipping(book, highlight));
            }

            return toReturn;
        }


    }
}
