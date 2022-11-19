using CommunityToolkit.Mvvm.ComponentModel;
using CrazyElephant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.ViewModels
{
    public class DishMenuItemViewModel: ObservableObject
    {
        public Dish Dish { get; set; }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.OnPropertyChanged("isSelected");
            }
        }
    }
}
