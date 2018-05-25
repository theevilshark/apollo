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
        private readonly Button buttonControl;

        public ButtonManager(Button button, MainWindow window, int timeInSeconds = 5)
        {
            Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(timeInSeconds) };
            buttonControl = button;
            window.SizeChanged += OnWindowSizeChanged;
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
                From = 75,
                To = buttonControl.ActualWidth,
                Duration = Timer.Interval,
                EasingFunction = new QuarticEase(),
                FillBehavior = FillBehavior.Stop
            };
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ButtonWidthAnimation.To = buttonControl.ActualWidth;
        }
    }
}