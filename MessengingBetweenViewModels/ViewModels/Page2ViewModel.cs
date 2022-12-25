using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace MessengingBetweenViewModels.ViewModels
{
    partial class Page2ViewModel: ObservableObject
    {
        public Page2ViewModel()
        {
            // Register a message in some module
            WeakReferenceMessenger.Default.Register<LoggedInUserChangedMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.
                Message = m.Value;
            });
        }

        [ObservableProperty]
        private string message;
    }
}
