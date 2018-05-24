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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ClickerGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Int32 wood;
        DispatcherTimer timer;
        DoubleAnimation buttonWidthAnimation;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += Timer_Tick;
            this.SizeChanged += OnWindowSizeChanged;

            buttonWidthAnimation = new DoubleAnimation
            {
                From = 0,
                To = WoodButton.ActualWidth,
                Duration = timer.Interval,
                EasingFunction = new QuarticEase(),
                FillBehavior = FillBehavior.Stop
            };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            WoodButton.IsEnabled = true;
            timer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WoodDisplay.Text = (++wood).ToString();
            WoodButton.IsEnabled = false;
            timer.Start();
            WoodButton.BeginAnimation(WidthProperty, buttonWidthAnimation);
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WoodButton.Width = e.NewSize.Width - 8;
            buttonWidthAnimation.To = e.NewSize.Width - 8;
        }
    }
}
