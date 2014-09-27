namespace ClippingsExplorer.Entities
{
    public class Clipping
    {
        public Book BookInfo { get; private set; }
        public HighlightItem Highlight { get; private set; }


        public Clipping(Book bookInfo, HighlightItem highlight)
        {
            Highlight = highlight;
            BookInfo = bookInfo;
        }
    }
}
