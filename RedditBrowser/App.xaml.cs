using Microsoft.Extensions.DependencyInjection;
using RedditBrowser.Services;
using RedditBrowser.ViewModels;
using Refit;
using System;
using System.Windows;

namespace RedditBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Services = ConfigureServices();
        }
        public new static App Current { 
            get { return (App)Application.Current; } 
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(RestService.For<IRedditService>("https://www.reddit.com/"));

            services.AddTransient<PostWidgetViewModel>();
            services.AddTransient<SubredditWidgetViewModel>();

            services.AddSingleton<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}
