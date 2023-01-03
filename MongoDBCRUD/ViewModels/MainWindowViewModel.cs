using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDBCRUD.Models;
using MongoDBCRUD.Services;
using System.Collections.ObjectModel;

namespace MongoDBCRUD.ViewModels;

public partial class MainWindowViewModel: ObservableObject
{
	private readonly MongoDBSerivce _mongoDBSerivce;
	public MainWindowViewModel(MongoDBSerivce mongoDBSerivce)
	{
		this._mongoDBSerivce = mongoDBSerivce;
	}

	[ObservableProperty]
	public ObservableCollection<DatabaseNameModel> databaseNames = new();

	[RelayCommand]
	private async void LogDatabaseNames()
	{
		var db = await this._mongoDBSerivce.GetDatabaseNamesAsync();

		/*
		 * ��BsonDocument����ת���ɶ�Ӧ��Model��ͬʱ, ����List
		 */
		databaseNames.Clear();
		foreach (var item in db)
		{
			databaseNames.Add(
				new DatabaseNameModel(
					name: (string)item["name"],
					sizeOnDisk: (long)item["sizeOnDisk"],
					isEmpty: (bool)item["empty"]));
		}
	} 
}