using Microsoft.Extensions.DependencyInjection;
using MongoDBDemo.Models;
using System.Windows.Controls;

namespace MongoDBDemo.Pages
{
    /// <summary>
    /// MongoDBPage.xaml 的交互逻辑
    /// </summary>
    public partial class MongoDBPage : Page
    {
        public MongoDBPage()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<MongoDBPageViewModel>();
        }
    }
}
