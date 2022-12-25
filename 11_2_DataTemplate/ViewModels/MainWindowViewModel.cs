using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace _11_2_DataTemplate;

partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private Car selectedItem;
    
    public List<Car> CarList { get; } = new List<Car>();

    public MainWindowViewModel()
    {
        CarList.Add(new Car() { Automaker = "Lamborghini", Name = "benz", Year = "1990", TopSpeed = "340" });
        CarList.Add(new Car() { Automaker = "Lamborghini", Name = "binli", Year = "1990", TopSpeed = "340" });
        CarList.Add(new Car() { Automaker = "Lamborghini", Name = "micar", Year = "1990", TopSpeed = "340" });
        CarList.Add(new Car() { Automaker = "Lamborghini", Name = "xiaopeng", Year = "1990", TopSpeed = "340" });
        
    }
}