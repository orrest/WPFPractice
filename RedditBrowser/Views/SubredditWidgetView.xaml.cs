using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RedditBrowser.ViewModels;
using System.Windows.Controls;

namespace RedditBrowser.Views
{
    /// <summary>
    /// SubredditWidgetView.xaml 的交互逻辑
    /// </summary>
    public partial class SubredditWidgetView : Page
    {
        public SubredditWidgetView()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<SubredditWidgetViewModel>();
        }
    }
}
