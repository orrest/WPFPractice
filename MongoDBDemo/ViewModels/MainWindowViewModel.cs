using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MongoDBDemo.ViewModels;

public partial class MainWindowViewModel: ObservableObject
{
    [ObservableProperty]
    public string currentPage;

    public MainWindowViewModel()
    {
        CurrentPage = "/Views/ContentPage.xaml";
    }

    [RelayCommand]
    public void NavigateToContent()
    {
        CurrentPage = "/Views/ContentPage.xaml";
    }

    [RelayCommand]
    public void NavigateToMongoDB()
    {
        CurrentPage = "/Views/MongoDBPage.xaml";
    }
}