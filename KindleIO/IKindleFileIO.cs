namespace ClippingsExplorer.KindleIO
{
    public interface IKindleFileIO
    {
        KindleLoadResult GetKindleClippingsFile(string fileName);
    }
}