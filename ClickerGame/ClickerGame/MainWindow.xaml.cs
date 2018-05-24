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
        WoodManager woodManager;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            woodManager = new WoodManager(2, this.WoodButton, this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button) sender).Name)
            {
                case "WoodButton":
                    WoodDisplay.Text = (++woodManager.Wood).ToString();
                    WoodButton.IsEnabled = false;
                    woodManager.Timer.Start();
                    WoodButton.BeginAnimation(WidthProperty, woodManager.ButtonWidthAnimation);
                    break;

                default:
                    break;
            }
        }

        
    }
}
