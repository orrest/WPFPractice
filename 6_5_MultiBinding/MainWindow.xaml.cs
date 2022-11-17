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

namespace _6_5_MultiBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetMultiBinding();
        }

        private void SetMultiBinding()
        {
            // 绑定控件的属性. 自己作为数据源更新自己的属性.
            Binding nameBinding1 = new Binding("Text") { Source = this.nameBox1 };
            Binding nameBinding2 = new Binding("Text") { Source = this.nameBox2 };
            Binding emailBinding1 = new Binding("Text") { Source = this.emailBox1 };
            Binding emailBinding2 = new Binding("Text") { Source = this.emailBox2 };

            // 上面这些Binding的源将被输出给MultiBinding的Target,
            // 这个过程中就涉及到MultiConverter.
            MultiBinding multiBinding = new MultiBinding() { Mode = BindingMode.OneWay };
            multiBinding.Bindings.Add(nameBinding1);
            multiBinding.Bindings.Add(nameBinding2);
            multiBinding.Bindings.Add(emailBinding1);
            multiBinding.Bindings.Add(emailBinding2);
            multiBinding.Converter = new LogonMultiBindingConverter();

            // MultiBinding的输出绑定到Button的IsEnabledProperty属性上,
            // 此时也确定了MultiConverter的输出类型.
            this.button1.SetBinding(Button.IsEnabledProperty, multiBinding);
        }
    }
}
