using ClickerGame.Processing;
using MvvmUtilities;
using ResourceManagement.Buildings;
using System.Windows.Input;

namespace ClickerGame.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private const double TicksPerSecond = 1;
        private const double GrowthInterval = 5;

        private double _wood;
        private bool _canUpgradeLumbermill;

        private readonly GameLoop _loop;

        public MainViewModel()
        {
            Lumbermill = new Lumbermill();

            _loop = new GameLoop(TicksPerSecond);
            _loop.Tick += () => Wood += (Lumbermill.Generate(TicksPerSecond * GrowthInterval));
            _loop.Start();

            Wood = 20;
            CanUpgradeLumbermill = Wood >= Lumbermill.UpgradeCost;
        }

        public Lumbermill Lumbermill { get; private set; }

        public bool CanUpgradeLumbermill
        {
            get { return _canUpgradeLumbermill; }
            set
            {
                if (_canUpgradeLumbermill == value) return;
                _canUpgradeLumbermill = value;
                NotifyPropertyChanged();
            }
        }
        public double Wood
        {
            get { return _wood; }
            set
            {
                if (_wood == value) return;
                _wood = value;
                NotifyPropertyChanged();
                CanUpgradeLumbermill = Wood >= Lumbermill.UpgradeCost;
            }
        }

        public ICommand Increment => new DelegateCommand(() => Wood++);
        public ICommand UpgradeLumbermill => new DelegateCommand(() =>
        {
            Wood -= Lumbermill.UpgradeCost;
            Lumbermill.Upgrade();
            NotifyPropertyChanged("Lumbermill");
        });
    }
}