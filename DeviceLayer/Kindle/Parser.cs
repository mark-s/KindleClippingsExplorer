using System;
using System.Collections.Generic;
using ClippingsExplorer.Entities;

namespace ClippingsExplorer.DeviceLayer.Kindle
{
    public class Parser : IParser
    {
        public IList<Clipping> ParseClippings(IList<string> itemsStrings)
        {
            if (itemsStrings.Count % 4 != 0)
                throw new FormatException("File in invalid!");

            var clippings = new List<Clipping>();

            for (int i = 0; i < itemsStrings.Count-1; i += 4)
            {
                var book = Book.GetBookFromString(itemsStrings[i]);
                
                var highlight = HighlightItem.GetItemFromString(itemsStrings[i + 1], itemsStrings[i + 2]);

                clippings.Add(new Clipping(book, highlight));
            }

            return clippings;
        }


    }
}
