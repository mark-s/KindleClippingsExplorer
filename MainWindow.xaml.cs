using ClippingsExplorer.ClippingsParser;
using ClippingsExplorer.KindleIO;

namespace ClippingsExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(new KindleFileIO(), new Parser());
        }
    }
}
