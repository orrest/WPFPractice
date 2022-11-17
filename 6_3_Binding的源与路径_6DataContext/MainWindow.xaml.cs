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

namespace _6_3_Binding的源与路径_6DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var stu = new Student();
            stu.Id = 5;
            stu.Name = "xxff";
            stu.Age = 5;
            this.stackPanel.DataContext = stu;

            this.textBox1.SetBinding(TextBox.TextProperty, new Binding("Id"));
            this.textBox2.SetBinding(TextBox.TextProperty, new Binding("Name"));
            this.textBox3.SetBinding(TextBox.TextProperty, new Binding("Age"));
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
