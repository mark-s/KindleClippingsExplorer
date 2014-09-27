using System.Collections.Generic;

namespace ClippingsExplorer.DeviceLayer
{
    public class LoadResult
    {
        public bool Success { get; set; }
        public string ErrorText { get; set; }
        public List<string> FileContents { get; set; }

        public LoadResult()
        {
            FileContents  = new List<string>();
        }
    }
}
