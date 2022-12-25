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

namespace _11_4_DataTemplate与ControlTemplate_3_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 我感觉有点问题. 这里面是没涉及到MVVM的事儿吧? 所以这种还是Winform风格的编程方式.
            // 实际上在MVVM中, 直接操作属性就好了, 不需要通过控件获得属性.
            TextBlock tb = this.cp.ContentTemplate.FindName("textBlockName", this.cp) as TextBlock;
            var s = tb.Text;
        }
    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public bool HasJob { get; set; }
    }
}
