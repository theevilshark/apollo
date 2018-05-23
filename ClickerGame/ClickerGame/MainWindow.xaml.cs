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

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(Object sender, EventArgs e)
        {
            WoodButton.IsEnabled = true;
            timer.Stop();
        }

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            WoodDisplay.Text = (++wood).ToString();
            WoodButton.IsEnabled = false;
            timer.Start();
        }
    }
}
