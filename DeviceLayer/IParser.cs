using System.Collections.Generic;
using ClippingsExplorer.Entities;

namespace ClippingsExplorer.DeviceLayer
{
    public interface IParser
    {
        IList<Clipping> ParseClippings(IList<string> itemsStrings);
    }
}