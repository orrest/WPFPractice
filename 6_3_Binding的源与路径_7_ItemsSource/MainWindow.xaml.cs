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

namespace _6_3_Binding的源与路径_7_ItemsSource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Student> students = new List<Student>()
            {
                new Student() { Id=0, Name="Tim", Age=29 },
                new Student() { Id=1, Name="Jerry", Age=23 },
                new Student() { Id=2, Name="Tom", Age=25 },
                new Student() { Id=3, Name="Json", Age=69 },
                new Student() { Id=4, Name="Emma", Age=79 },
                new Student() { Id=5, Name="Star", Age=129 },
                new Student() { Id=6, Name="Light", Age=23 },
            };
            // 将 stu list 设置给ListBox.
            this.listBoxStudents.ItemsSource = students;
            this.listBoxStudents.DisplayMemberPath = "Name";

            // textBoxId 绑定到 item 的 Id 上.
            Binding binding = new Binding("SelectedItem.Id") { Source = this.listBoxStudents };
            this.textBoxId.SetBinding(TextBox.TextProperty, binding);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
