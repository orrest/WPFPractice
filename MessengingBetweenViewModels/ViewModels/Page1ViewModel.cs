using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace MessengingBetweenViewModels.ViewModels
{
    partial class Page1ViewModel: ObservableObject
    {
        [RelayCommand]
        private void SendMsg()
        {
            // Send a message from some other module
            WeakReferenceMessenger.Default.Send(new LoggedInUserChangedMessage("From page 1."));
        }
    }
}
