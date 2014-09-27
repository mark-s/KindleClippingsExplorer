using System;
using System.Text.RegularExpressions;

namespace ClippingsExplorer.Entities
{
    public class HighlightItem
    {
        private static readonly Regex _locationRegex = new Regex(@".*\((.*)\)", RegexOptions.Compiled);
        private static readonly Regex _dateRegex = new Regex(@"Added on.*,\s(.*)", RegexOptions.Compiled);


        public string Location { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public String Text { get; private set; }

        public static HighlightItem EmptyHighlightItem = new HighlightItem(string.Empty, DateTime.MinValue, "No Data");
            
        
        private HighlightItem(string location, DateTime timeStamp, string text)
        {
            Text = text;
            TimeStamp = timeStamp;
            Location = location;
        }

        
        public  static HighlightItem GetItemFromString(string headerString, string contentString)
        {
            var location = GetLocation(headerString);
            var timeStamp = GetTimeStamp(headerString);

            return new HighlightItem(location, timeStamp, contentString);
        }

        private static string GetLocation(string rawString)
        {
            var matched = _locationRegex.Match(rawString);

            if (matched.Success == false)
                return "unknown!";
            else
                return matched.Groups[1].Value;
        }

        private static DateTime GetTimeStamp(string rawString)
        {
            var toReturn = DateTime.MinValue;

            var matched = _dateRegex.Match(rawString);

            if (matched.Success)
                DateTime.TryParse(matched.Groups[1].Value, out toReturn);

            return toReturn;
        }


    }
}