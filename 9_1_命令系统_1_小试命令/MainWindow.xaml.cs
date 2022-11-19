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

namespace _9_1_命令系统_1_小试命令
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }

        // 1. 2. 声明并创建命令
        private RoutedCommand clearCmd = new RoutedCommand(
            "Clear", typeof(MainWindow)    
        );

        private void InitializeCommand()
        {
            this.clearCmd.InputGestures
                .Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            // 3. 指定命令源(触发命令的控件)
            this.button1.Command = this.clearCmd;
   
            // 4. 指定命令目标(接受命令的控件)
            this.button1.CommandTarget = this.textBoxA;

            // 5. 设置命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCmd;
            cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);
            // CommandBinding要设置在命令目标的外围控件上, 不然无法捕获事件.
            this.stackPanel.CommandBindings.Add(cb);
        }

        private void cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxA.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            e.Handled = true;
        }

        private void cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.textBoxA.Clear();
            e.Handled = true;
        }
    }
}
