using System;

namespace ClippingsExplorer
{
    public class DataLoadException : Exception
    {

        public DataLoadException()
        {
        }

        public DataLoadException(string message)
            : base(message)
        {
        }

        public DataLoadException(string message, Exception inner)
            : base(message, inner)
        {
        }


    }
}