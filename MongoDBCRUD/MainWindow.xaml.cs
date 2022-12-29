using System.Windows;
using Microsoft.Extensions.Options;

namespace MongoDBCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IOptions<ConnectionStrings> secrets)
        {
            InitializeComponent();
            _secrets = secrets.Value;
        }

        private readonly ConnectionStrings _secrets;
    }
}
