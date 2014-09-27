using ClippingsExplorer.Properties;

namespace ClippingsExplorer.ServiceLayer
{
    public interface ISettingsRepo
    {
        string GetClippingsFileName();
        void SaveClippingsFileName(string fileName);
    }

    public class SettingsRepo : ISettingsRepo
    {
        public string GetClippingsFileName()
        {
            return Settings.Default.ClippingsFileName;
        }

        public void SaveClippingsFileName(string fileName)
        {
            Settings.Default.ClippingsFileName = fileName;
            Settings.Default.Save();
        }

    }
}
