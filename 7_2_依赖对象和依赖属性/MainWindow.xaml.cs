using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _7_2_依赖对象和依赖属性
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }
    }
    public class FakeTextBox: TextBox
    {
        /// <summary>
        /// CLR Property Wrapper for DependencyProperty.
        /// </summary>
        public string Fake
        {
            get { return (string)GetValue(TextProperty); }
            set 
            { 
                SetValue(FakeProperty, value);
                SetValue(TextProperty, value);
            }
        }

        public static readonly DependencyProperty FakeProperty = 
            DependencyProperty.Register("Fake", typeof(string), typeof(FakeTextBox));

    }
}
