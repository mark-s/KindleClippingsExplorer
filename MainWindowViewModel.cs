using System;
using System.Collections.ObjectModel;
using ClippingsExplorer.ClippingsParser;
using ClippingsExplorer.Entities;
using ClippingsExplorer.KindleIO;

namespace ClippingsExplorer
{
    public class MainWindowViewModel
    {

        public ObservableCollection<Clipping> Data;

        public MainWindowViewModel(IKindleFileIO kindleFileIO, IParser parser)
        {
            var fileResult = kindleFileIO.GetKindleClippingsFile(@"J:\documents\My Clippings.txt");

            if (!fileResult.Success)
            {
                throw new NotImplementedException("HANDLE THIS " + fileResult.ErrorText);
                return;
            }

            Data = new ObservableCollection<Clipping>(parser.ParseClippings(fileResult.FileContents));

        }
    }
}
