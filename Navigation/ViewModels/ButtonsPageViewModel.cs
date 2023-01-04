using CommunityToolkit.Mvvm.ComponentModel;

namespace Navigation.ViewModels
{
    partial class ButtonsPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private string content = "There is something from back end view model.";
    }
}
