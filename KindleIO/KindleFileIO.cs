using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClippingsExplorer.KindleIO
{
    public class KindleFileIO : IKindleFileIO
    {
        private const string DIVIDER = "==========";

        private readonly string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

        public KindleLoadResult GetKindleClippingsFile(string fileName)
        {

            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName", "Filename is needed!");

            if (File.Exists(fileName) == false)
                throw new FileLoadException(fileName + " Does not exist!");

            var result = new KindleLoadResult();
            try
            {
                // BLOODY BYTE ORDER MARK!!!11
                var allLines = File.ReadAllLines(fileName);

                foreach (var content in allLines.Where(line => (line != DIVIDER)))
                    result.FileContents.Add(content.Replace(_byteOrderMarkUtf8, string.Empty));
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
