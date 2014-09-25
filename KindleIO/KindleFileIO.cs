using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ClippingsExplorer.KindleIO
{
    public class KindleFileIO : IKindleFileIO
    {

        private const string DIVIDER = "==========";

        public KindleLoadResult GetKindleClippingsFile(string fileName)
        {

            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName", "Filename is needed!");

            if (File.Exists(fileName) == false)
                throw new FileLoadException(fileName + " Does not exist!");

            var result = new KindleLoadResult();
            try
            {
                var contents = File.ReadAllLines(fileName);
                result.FileContents.AddRange(contents.Where(line => (!String.IsNullOrEmpty(line) && line != DIVIDER)));
                result.Success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[GetKindleClippingsFile()]\t" + ex.Message);

             
                result.ErrorText = ex.Message;
            }
            return result;
        }


    }
}
