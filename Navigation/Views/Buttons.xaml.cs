using Navigation.ViewModels;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMSampleAppWpf.Views
{
    /// <summary>
    /// Buttons.xaml 的交互逻辑
    /// </summary>
    public partial class Buttons : Page
    {
        public Buttons()
        {
            InitializeComponent();

            this.DataContext = new ButtonsPageViewModel();

            /**
             * The reprint of this message indicates that every time when you navigate to a page, 
             * this page will just initialize a new object.
             * 
             * We can use DI to ensure that, the Page could be different objects, but the context(view model)
             * still be the same "singleton".
             * */
            Debug.WriteLine($"Page: '{this.GetType().Name}' initialized again!");
        }
    }
}
