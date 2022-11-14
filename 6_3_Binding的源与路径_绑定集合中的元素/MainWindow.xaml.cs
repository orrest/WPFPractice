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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6_3_Binding的源与路径_绑定集合中的元素
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> list = new List<string>()
            {
                "Tim", "Tom", "Blog"
            };

            // '/'代表根元素, '/[2]'代表根元素的第三个字母.
            this.textBox1.SetBinding(TextBox.TextProperty,
                new Binding("/") { Source = list });
            this.textBox2.SetBinding(TextBox.TextProperty,
                new Binding("/Length") { Source = list, Mode = BindingMode.OneWay });
            this.textBox3.SetBinding(TextBox.TextProperty,
                new Binding("/[2]") { Source = list, Mode = BindingMode.OneWay });
        }
    }
}
