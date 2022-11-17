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

namespace _6_4_Binding对数据的转换与校验_2_数据转换
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

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> planes = new List<Plane>()
            {
                new Plane(){Category=Category.Bomber, Name="B-1", State=State.Unknown },
                new Plane(){Category=Category.Bomber, Name="B-2", State=State.Unknown },
                new Plane(){Category=Category.Fighter, Name="F-22", State=State.Unknown },
                new Plane(){Category=Category.Fighter, Name="Su-47", State=State.Unknown },
                new Plane(){Category=Category.Bomber, Name="B-52", State=State.Unknown },
                new Plane(){Category=Category.Fighter, Name="J-10", State=State.Unknown },
            };
            this.listBoxPlane.ItemsSource = planes;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public enum Category
    {
        Bomber, Fighter
    }

    public enum State
    {
        Available, Locked, Unknown
    }

    public class Plane
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }
}
