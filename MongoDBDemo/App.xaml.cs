using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDBDemo.Models;
using MongoDBDemo.Services;
using MongoDBDemo.ViewModels;
using System;
using System.IO;
using System.Windows;

namespace MongoDBDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public App()
        {
            this.Services = ConfigureServices();
        }

        public new static App Current
        {
            get { return (App)Application.Current; }
        }

        private IServiceProvider? ConfigureServices()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("secrets.json", optional: false, reloadOnChange: true)
                        .AddUserSecrets<ConnectionStrings>()
                        .AddEnvironmentVariables().Build();

            var services = new ServiceCollection()
                .Configure<ConnectionStrings>(builder.GetSection(nameof(ConnectionStrings)))
                .AddOptions()
                .AddSingleton<MongoDBSerivce>()
                .AddSingleton<ContentPageViewModel>()
                .AddSingleton<MongoDBPageViewModel>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<MainWindow>()
                .BuildServiceProvider();

            return services;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = Services.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

    public class ConnectionStrings
    {
        public string MongoDB { get; set; }
    }
}
