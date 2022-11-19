using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyElephant.Models;
using CrazyElephant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CrazyElephant.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public RelayCommand PlaceOrderCommand { get; set; }
        public RelayCommand SelectMenuItemCommand { get; set; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.OnPropertyChanged("Count");
            }
        }

        private Restaurant restaurant;
        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.OnPropertyChanged("Restaurant");
            }
        }

        private List<DishMenuItemViewModel> dishMenu;
        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.OnPropertyChanged("DishMenu");
            }
        }

        public MainWindowViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new RelayCommand(
                new Action(this.PlaceOrderCommandExecute));
            this.SelectMenuItemCommand = new RelayCommand(
                new Action(this.SelectMenuItemExecute));
        }

        private void SelectMenuItemExecute()
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true);
        }

        private void PlaceOrderCommandExecute()
        {
            var selectedDishes = this.DishMenu.Where(i => i.IsSelected == true)
                .Select(i => i.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功!");
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Crazy大象";
            this.Restaurant.Address = "北京市海淀区万泉河路紫金庄园";
        }
    }
}
