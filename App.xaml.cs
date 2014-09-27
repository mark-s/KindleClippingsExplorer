using System.Runtime.Hosting;
using System.Windows;
using ClippingsExplorer.DeviceLayer;
using ClippingsExplorer.DeviceLayer.Kindle;
using ClippingsExplorer.ServiceLayer;
using GalaSoft.MvvmLight.Ioc;

namespace ClippingsExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            SimpleIoc.Default.Register<IDiskIO, DiskIO>();
            SimpleIoc.Default.Register<IParser, Parser>();
            SimpleIoc.Default.Register<ISettingsRepo, SettingsRepo>();
            SimpleIoc.Default.Register<IClippingsRepository, ClippingsRepository>();
        }

    }
}
