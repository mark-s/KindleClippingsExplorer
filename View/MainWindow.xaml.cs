using ClippingsExplorer.ClippingsParser;
using ClippingsExplorer.KindleIO;
using ClippingsExplorer.ViewModel;

namespace ClippingsExplorer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel(new KindleFileIO(), new Parser());
            this.DataContext = vm;
        }
    }
}
