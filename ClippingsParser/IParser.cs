using System.Collections.Generic;
using ClippingsExplorer.Entities;

namespace ClippingsExplorer.ClippingsParser
{
    public interface IParser
    {
        List<Clipping> ParseClippings(IList<string> itemsStrings);
    }
}