using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventDemo
{
    /// <summary>
    /// 事件拥有者是事件响应者的一个字段成员
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 事件拥有者和事件处理者是单独的两个类
            //TimerEventOwner.Start();
            Controller controller = new Controller(this);

            // 一个类, 同时拥有事件和事件处理方法
            MyWindow window = new MyWindow();
            window.MouseDoubleClick += window.WindowDoubleClicked;
            window.Show();

            // 事件拥有者是事件响应者的一个字段成员
            this.button.Click += Button_Click;
            // 这里是手动注册的, 也可以直接在xaml中通过双击"属性"中的事件自动添加注册.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "Hello World";
        }
    }

    #region 事件拥有者和事件处理者是单独的两个类
    public class TimerEventOwner
    {
        static Timer timer = new Timer();

        public static void Start()
        {
            Register();
            timer.Interval = 1000;
            timer.Start();
        }

        private static void Register()
        {
            timer.Elapsed += TimerEventHandler.Timer_Elapsed;
        }
    }

    public class TimerEventHandler
    {
        internal static void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Timer: {e.SignalTime}");
        }
    }

    /// <summary>
    /// MVC 雏形.
    /// </summary>
    class Controller
    {
        private Window window;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="window"></param>
        public Controller(Window window)
        {
            if (window != null)
            {
                this.window = window;
                // 事件注册
                this.window.MouseDoubleClick += Window_MouseDoubleClick;
            }
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.window.Title = DateTime.Now.ToString();
        }
    }
    #endregion

    #region 一个类, 同时拥有事件和事件处理方法
    class MyWindow : Window
    {
        internal void WindowDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            this.Title = $"The Sub Window: {DateTime.Now.ToString()}";
        }
    }
    #endregion

}