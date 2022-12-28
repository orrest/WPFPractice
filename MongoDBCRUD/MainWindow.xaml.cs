using System.Diagnostics;
using System.Windows;
using MongoDB.Driver;

namespace MongoDBCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var connStr = "mongodb+srv://zzhxufeng:xF092619@freeazuredb.yg9rj0r.mongodb.net/?retryWrites=true&w=majority";

            var settings = MongoClientSettings.FromConnectionString(connStr);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("sample_weatherdata");

            var dbList = database.ListCollectionNames().ToList();

            foreach (var item in dbList)
            {
                Debug.WriteLine(item);
            }
        }
    }
}
