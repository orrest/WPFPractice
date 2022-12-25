using MessengingBetweenViewModels.ViewModels;
using System.Windows.Controls;

namespace MessengingBetweenViewModels.Views
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            this.DataContext = new Page1ViewModel();
        }
    }
}
