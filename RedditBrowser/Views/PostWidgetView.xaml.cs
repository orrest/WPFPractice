using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RedditBrowser.ViewModels;
using System.Windows.Controls;

namespace RedditBrowser.Views
{
    /// <summary>
    /// PostWidgetView.xaml 的交互逻辑
    /// </summary>
    public partial class PostWidgetView : Page
    {
        public PostWidgetView()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<PostWidgetViewModel>();
        }
    }
}
