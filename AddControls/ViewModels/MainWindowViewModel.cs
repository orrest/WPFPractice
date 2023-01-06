using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddControls.ViewModels
{
    partial class MainWindowViewModel: ObservableObject
    {
        public ObservableCollection<SearchEntryViewModel> MySearchItems { get; set; } = new();

        [RelayCommand]
        public void AddControl()
        {
            MySearchItems.Add(new SearchEntryViewModel());
        }
    }

    partial class SearchEntryViewModel: ObservableObject
    {
        //Properties for Binding to Combobox and Textbox goes here
        [ObservableProperty]
        public string myPropertyInSearchEntryViewModel = "just write some content here.";
    }
}
