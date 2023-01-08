using Microsoft.Extensions.DependencyInjection;
using MongoDBDemo.ViewModels;
using System.Windows.Controls;

namespace MongoDBDemo.Pages
{
    /// <summary>
    /// ContentPage.xaml 的交互逻辑
    /// </summary>
    public partial class ContentPage : Page
    {
        public ContentPage()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<ContentPageViewModel>();
        }
    }
}
