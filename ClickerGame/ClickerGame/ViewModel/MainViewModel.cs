using ClickerGame.Processing;
using MvvmUtilities;
using ResourceManagement;
using ResourceManagement.Buildings;
using System.Windows.Input;

namespace ClickerGame.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private const double TicksPerSecond = 1;
        private const double GrowthIntervalInSeconds = 5;

        private IResourceCache _woodCache;
        private bool _canUpgradeLumbermill;

        private readonly GameLoop _loop;

        public MainViewModel()
        {
            var woodCache = new ResourceCache();
            _woodCache = new ObservableResourceCache(woodCache, () => NotifyPropertyChanged(nameof(Wood)));
            Lumbermill = new Lumbermill(_woodCache);

            _loop = new GameLoop(TicksPerSecond);
            _loop.Tick += () =>
            {
                Lumbermill.Generate(TicksPerSecond * GrowthIntervalInSeconds);
                UpdateCanUpgradeLumbermill();
            };
            _loop.Start();

            _woodCache.Apply(20);
            UpdateCanUpgradeLumbermill();
        }

        private void UpdateCanUpgradeLumbermill()
        {
            CanUpgradeLumbermill = _woodCache.Quantity >= Lumbermill.UpgradeCost;
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
        public double Wood => _woodCache.Quantity;

        public ICommand Increment => new DelegateCommand(() =>
        {
            _woodCache.Apply(1);
            UpdateCanUpgradeLumbermill();
        });

        public ICommand UpgradeLumbermill => new DelegateCommand(() =>
        {
            Lumbermill.Upgrade();
            UpdateCanUpgradeLumbermill();
            NotifyPropertyChanged(nameof(Lumbermill));
        });
    }
}
