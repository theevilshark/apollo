using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ClickerGame
{
    class WoodManager
    {
        public DoubleAnimation ButtonWidthAnimation;
        public DispatcherTimer Timer;
        public int Wood { get; set; } = 0;
        Button buttonControl;
        MainWindow mainWindow;

        public WoodManager(int timeInSeconds, Button button, MainWindow window)
        {
            Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            Timer.Tick += Timer_Tick;
            buttonControl = button;
            SetButtonAnimation();
            mainWindow = window;

            mainWindow.SizeChanged += OnWindowSizeChanged;
        }

        public WoodManager(Button button, MainWindow window)
        {
            Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            Timer.Tick += Timer_Tick;
            buttonControl = button;
            SetButtonAnimation();
            mainWindow = window;
            mainWindow.SizeChanged += OnWindowSizeChanged;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            buttonControl.IsEnabled = true;
            Timer.Stop();
        }

        private void SetButtonAnimation()
        {
            ButtonWidthAnimation = new DoubleAnimation
            {
                From = 0,
                To = buttonControl.ActualWidth,
                Duration = Timer.Interval,
                EasingFunction = new QuarticEase(),
                FillBehavior = FillBehavior.Stop
            };
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            buttonControl.Width = e.NewSize.Width - 8;
            ButtonWidthAnimation.To = e.NewSize.Width - 8;
        }
    }
}
