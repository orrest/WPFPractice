using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDBDemo.Services;
using System.Collections.ObjectModel;

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
                        isEmpty: (bool)item["empty"]))
                    );
            }
        }
    }

    partial class TextBoxViewModel: ObservableObject
    {
        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private double fontSize = 20.0;

        partial void OnDescriptionChanged(string value)
        {
            if (Description.StartsWith("/h1"))
            {
                Description = value.Replace("/h1", "");
                FontSize = 40.0;
            }
        }

        public TextBoxViewModel(DatabaseNameModel dbnm)
        {
            this.description = dbnm.Description;
        }
    }
}
