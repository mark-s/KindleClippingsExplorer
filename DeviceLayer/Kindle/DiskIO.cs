using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ClippingsExplorer.DeviceLayer.Kindle
{
    public class DiskIO : IDiskIO
    {
        private const string DIVIDER = "==========";

        // BLOODY BYTE ORDER MARK!!!11
        private readonly string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

        public LoadResult GetClippingsFile(string fileName)
        {

            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName", "valid filename (path + filename) required");

            var result = new LoadResult();

            if (File.Exists(fileName) == false)
            {
                result.Success = false;
                result.ErrorText = fileName + " does not exist!";
                return result;
            }

            try
            {
                var allLines = File.ReadAllLines(fileName);

                foreach (var content in allLines.Where(line => (line != DIVIDER)))
                    result.FileContents.Add(content.Replace(_byteOrderMarkUtf8, string.Empty));

                result.Success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[GetClippingsFile()]\t" + ex.Message);

                result.ErrorText = ex.Message;
            }


            return result;
        }


    }
}
