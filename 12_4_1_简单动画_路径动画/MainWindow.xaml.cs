using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace _12_4_1_简单动画_路径动画
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
            PathGeometry pg = this.LayoutRoot.FindResource("movingPath") as PathGeometry;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(600));

            DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
            dapX.PathGeometry = pg;
            dapX.Source = PathAnimationSource.X;
            dapX.Duration = duration;

            DoubleAnimationUsingPath dapY = new DoubleAnimationUsingPath();
            dapY.PathGeometry = pg;
            dapY.Source = PathAnimationSource.Y;
            dapY.Duration = duration;

            this.tt.BeginAnimation(TranslateTransform.XProperty, dapX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, dapY);
        }
    }
}
