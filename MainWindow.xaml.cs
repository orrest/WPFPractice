using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace WPFPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu;
        public MainWindow()
        {
            InitializeComponent();

            //stu = new Student();

            //// 创建一个键连对象.
            //Binding binding = new Binding()
            //{
            //    Source = stu,
            //    Path = new PropertyPath("Name")
            //};

            //// 执行键连.
            //BindingOperations.SetBinding(
            //    this.textBoxName, TextBox.TextProperty, binding);

            this.textBoxName.SetBinding(
                TextBox.TextProperty, 
                new Binding("Name") { Source = stu = new Student() }
            );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 只需要改变数据类对象的属性, UI就会自动发生变化.
            stu.Name += "Name";            
        }
    }

    class Student: INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get 
            { 
                return name; 
            }

            set 
            { 
                name = value; 
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }        
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
