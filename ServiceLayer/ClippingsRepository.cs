using System;
using System.Collections.Generic;
using System.Linq;
using ClippingsExplorer.DeviceLayer;
using ClippingsExplorer.Entities;

namespace ClippingsExplorer.ServiceLayer
{
    public class ClippingsRepository : IClippingsRepository
    {
        private readonly IDiskIO _diskIO;
        private readonly IParser _parser;
        private IList<Clipping> _clippings;
        private bool _loadDone;


        public ClippingsRepository(IDiskIO diskIO, IParser parser)
        {
            _diskIO = diskIO;
            _parser = parser;
        }

        public void LoadFromFile(string fileName)
        {
            LoadResult loadResult;
            try
            {
                loadResult = _diskIO.GetClippingsFile(fileName);
            }
            catch (Exception ex)
            {
                throw new DataLoadException(ex.Message);
            }

            if (loadResult.Success == false)
                throw new DataLoadException(loadResult.ErrorText);

            try
            {
                _clippings = _parser.ParseClippings(loadResult.FileContents);
            }
            catch (FormatException fex)
            {
                throw new DataLoadException(fex.Message);
            }

            _loadDone = true;
        }

        public IEnumerable<string> GetBookTitles()
        {
            if (_loadDone)
                return _clippings.Select(i => i.BookInfo.Title).Distinct().Skip(0);
            else
                return new List<string> {"No clippings loaded!!"};
        }

        public IEnumerable<HighlightItem> GetHighlightsForBook(string bookTitle)
        {
            if (_loadDone)
                return (_clippings.Where(i => i.BookInfo.Title == bookTitle).Select(b => b.Highlight)).Skip(0);
            else
                return new List<HighlightItem> { HighlightItem.EmptyHighlightItem };
        }
    }
}
