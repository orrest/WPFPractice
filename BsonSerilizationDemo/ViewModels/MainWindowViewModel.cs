using BsonSerilizationDemo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BsonSerilizationDemo.ViewModels
{
    partial class MainWindowViewModel: ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private bool sold;

        private readonly MongoDBSerivce _service;
        public MainWindowViewModel(MongoDBSerivce service)
        {
            _service = service;
        }

        [RelayCommand]
        private async void GetBookByName()
        {
            var book = await _service.GetBookByNameAsync("人与自然");

            if (book == null) { return; }

            Name = book.Name;
            Sold = book.Sold;
        }
    }
}
