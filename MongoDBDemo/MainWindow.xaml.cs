using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MongoDBCRUD.ViewModels;

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
            this.DataContext = App.Current.Services.GetService<MainWindowViewModel>();
        }
    }
}
