using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MongoDBDemo.ViewModels
{
    partial class ContentPageViewModel : ObservableObject
    {
        public ObservableCollection<ContentBoxViewModel> AddedItems { get; set; } = new();

        [RelayCommand]
        public void AddControl()
        {
            AddedItems.Add(new ContentBoxViewModel());
        }
    }

    partial class ContentBoxViewModel: ObservableObject
    {
        [ObservableProperty]
        private string textBlockText = "I'm a text block";
    }
}
