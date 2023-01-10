using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDBDemo.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace MongoDBDemo.Models
{
    partial class MongoDBPageViewModel: ObservableObject
    {
        private readonly MongoDBSerivce _mongoDBSerivce;
        public MongoDBPageViewModel(MongoDBSerivce mongoDBSerivce)
        {
            this._mongoDBSerivce = mongoDBSerivce;
        }

        [ObservableProperty]
        public ObservableCollection<TextBoxViewModel> databaseNames = new();

        [ObservableProperty]
        public int selectedIndex = 0;

        [RelayCommand]
        private async void LogDatabaseNames()
        {
            var db = await this._mongoDBSerivce.GetDatabaseNamesAsync();

            /*
             * 将BsonDocument类型转换成对应的Model的同时, 更新List
             * 
             * 这个地方仿佛可以直接用实体类来做, 类似Json那种.
             */
            databaseNames.Clear();
            foreach (var item in db)
            {
                databaseNames.Add(
                    new TextBoxViewModel(new DatabaseNameModel(
                        name: (string)item["name"],
                        sizeOnDisk: (long)item["sizeOnDisk"],
                        isEmpty: (bool)item["empty"]),
                        this
                    ));
            }
        }

        [RelayCommand]
        public void AddTextBox()
        {
            databaseNames.Insert(
                selectedIndex,
                new TextBoxViewModel(
                    new DatabaseNameModel("the new added one", 10, true), 
                    this));
        }
    }

    partial class TextBoxViewModel: ObservableObject
    {
        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private double fontSize = 16.0;

        private MongoDBPageViewModel parentVm;

        partial void OnDescriptionChanged(string value)
        {
            if (Description.StartsWith("/1"))
            {
                Description = value.Replace("/1", "");
                FontSize = 22.0;
            }
        }

        public TextBoxViewModel(DatabaseNameModel dbnm, MongoDBPageViewModel parentVm)
        {
            this.description = dbnm.Description;
            this.parentVm = parentVm;
        }

        [RelayCommand]
        private void AddTextBox()
        {
            parentVm.AddTextBoxCommand.Execute(null);
        }
    }
}
