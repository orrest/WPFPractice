
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDBCRUD.Services;

namespace MongoDBCRUD.ViewModels;

public partial class MainWindowViewModel: ObservableObject
{
	private readonly MongoDBSerivce _mongoDBSerivce;
	public MainWindowViewModel(MongoDBSerivce mongoDBSerivce)
	{
		this._mongoDBSerivce = mongoDBSerivce;
	}

	[RelayCommand]
	private void LogDatabaseNames()
	{
		this._mongoDBSerivce.GetDatabaseNamesAsync();
	} 
}