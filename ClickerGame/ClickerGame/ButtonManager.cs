using System;
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

        public ButtonManager(Button button, int timeInSeconds = 5)
        {
            Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(timeInSeconds) };
            buttonControl = button;
            Timer.Tick += Timer_Tick;
            SetButtonAnimation();
        }

        public void RefreshAnimationParameters()
        {
            // TODO Needs further consideration for resizing mid animation to adjust that single instance.
            if (Timer.IsEnabled)
                Timer.Tick += handler;
            else
                ResetButtonWidthAnimation();

            void handler(object sender, EventArgs e)
            {
                ResetButtonWidthAnimation();
                Timer.Tick -= handler;
            }
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

        private void ResetButtonWidthAnimation() => ButtonWidthAnimation.To = buttonControl.ActualWidth;
    }
}
