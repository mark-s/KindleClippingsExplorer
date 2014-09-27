namespace ClippingsExplorer.DeviceLayer
{
    public interface IDiskIO
    {
        LoadResult GetClippingsFile(string fileName);
    }
}