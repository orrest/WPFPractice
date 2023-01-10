using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TextBoxSizeChange
{
    partial class MainWindowViewModel: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<TextBoxViewModel> databaseNames = new();

        public MainWindowViewModel()
        {
            databaseNames.Add(new TextBoxViewModel());
            databaseNames.Add(new TextBoxViewModel());
        }
    }

    partial class TextBoxViewModel: ObservableObject
    {
        [ObservableProperty]
        private string text = "something";
    }
}
