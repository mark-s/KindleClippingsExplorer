using System.Collections.Generic;

namespace ClippingsExplorer.KindleIO
{
    public class KindleLoadResult
    {
        public bool Success { get; set; }
        public string ErrorText { get; set; }
        public List<string> FileContents { get; set; }

        public KindleLoadResult()
        {
            FileContents  = new List<string>();
        }
    }
}
