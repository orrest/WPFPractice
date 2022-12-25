﻿using MessengingBetweenViewModels.ViewModels;
using System.Windows.Controls;

namespace MessengingBetweenViewModels.Views
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            this.DataContext = new Page2ViewModel();
        }
    }
}
