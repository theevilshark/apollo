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
    class ButtonManager
    {
        public DoubleAnimation ButtonWidthAnimation;
        public DispatcherTimer Timer;
        Button buttonControl;
        MainWindow mainWindow;

        public ButtonManager(Button button, MainWindow window, int timeInSeconds = 5)
        {
            Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(timeInSeconds) };
            buttonControl = button;
            mainWindow = window;
            mainWindow.SizeChanged += OnWindowSizeChanged;
            Timer.Tick += Timer_Tick;
            SetButtonAnimation();
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
