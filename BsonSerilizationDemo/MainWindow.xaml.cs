using BsonSerilizationDemo.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BsonSerilizationDemo
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
