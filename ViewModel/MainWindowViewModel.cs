using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ClippingsExplorer.ClippingsParser;
using ClippingsExplorer.Entities;
using ClippingsExplorer.KindleIO;

namespace ClippingsExplorer.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<String> Books { get; private set; }
        
        public MainWindowViewModel(IKindleFileIO kindleFileIO, IParser parser)
        {
            var fileResult = kindleFileIO.GetKindleClippingsFile(@"G:\My Clippings.txt");

            if (!fileResult.Success)
                throw new NotImplementedException("HANDLE THIS " + fileResult.ErrorText);

         var res = parser.ParseClippings(fileResult.FileContents);

            var rrr = res.Select(i => i.BookInfo.Title).Distinct();

            Books = new ObservableCollection<string>(rrr);


        }
    }
}
