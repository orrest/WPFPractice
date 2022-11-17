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

namespace _6_4_Binding对数据的转换与校验_1_Binding数据校验
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding("Value") { Source = this.slider1 };
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            var rvr = new RangeValidationRule();
            // 如果不设置, 不会校验来自Source(slider1)的输入.
            rvr.ValidatesOnTargetUpdated = true;
            binding.ValidationRules.Add(rvr);
            binding.NotifyOnValidationError = true;
            this.textBox1.SetBinding(TextBox.TextProperty, binding);
            this.textBox1.AddHandler(
                Validation.ErrorEvent,
                new RoutedEventHandler(this.ValidationError)
            );

        }

        private void ValidationError(object sender, RoutedEventArgs e)
        {
            if(Validation.GetErrors(this.textBox1).Count > 0)
            {
                this.textBox1.ToolTip = Validation
                    .GetErrors(this.textBox1)[0]
                    .ErrorContent
                    .ToString();
            }
        }
    }
}
