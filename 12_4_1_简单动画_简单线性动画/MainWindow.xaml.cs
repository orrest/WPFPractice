using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace _12_4_1_简单动画_简单线性动画
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

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //DoubleAnimation daX = new DoubleAnimation();
            //DoubleAnimation daY = new DoubleAnimation();

            ////daX.From= 0;
            ////daY.From= 0;

            //Random r = new Random();
            //daX.To = r.NextDouble() * 300;
            //daY.To = r.NextDouble() * 300;

            //Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            //daX.Duration = duration;
            //daY.Duration = duration;

            //// 动画的主体是TranslateTransform, 而非Button.
            //// Button的显示位置发生了变化, 但实际位置并没有发生变化.
            //this.tt.BeginAnimation(TranslateTransform.XProperty, daX);
            //this.tt.BeginAnimation(TranslateTransform.YProperty, daY);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation daX = new DoubleAnimation();
            DoubleAnimation daY = new DoubleAnimation();

            BounceEase be = new BounceEase();
            be.Bounces = 3;
            be.Bounciness = 2;
            daX.EasingFunction = be;
            daX.AccelerationRatio = 0.5;
            daX.AutoReverse= true;
            daY.AutoReverse= true;

            daX.To = 300;
            daY.To = 300;

            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            daX.Duration = duration;
            daY.Duration = duration;

            // 动画的主体是TranslateTransform, 而非Button.
            // Button的显示位置发生了变化, 但实际位置并没有发生变化.
            this.tt.BeginAnimation(TranslateTransform.XProperty, daX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, daY);
        }
    }
}
