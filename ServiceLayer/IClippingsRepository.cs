using System.Collections.Generic;
using ClippingsExplorer.Entities;

namespace ClippingsExplorer.ServiceLayer
{
    public interface IClippingsRepository
    {
        /// <summary>
        /// Populates the Repo with all clippings data from the clippings file
        /// </summary>
        /// <exception cref="DataLoadException">Throws if the file fails to load</exception>
        /// <param name="fileName">file name + path to load</param>
        void LoadFromFile(string fileName);

        IEnumerable<string> GetBookTitles();

        IEnumerable<HighlightItem> GetHighlightsForBook(string bookTitle);
    }
}