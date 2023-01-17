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
        private async void GetMagazineByName()
        {
            var book = await _service.GetMagazineByNameAsync("人与自然");

            if (book == null) { return; }

            Name = book.Name;
            Sold = book.Sold;
        }

        [RelayCommand]
        private void PutBook()
        {
            _service.PutBookAsync();
        }
    }
}
