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

        private IResourceCache _woodCache;

        private readonly GameLoop _loop;

        public MainViewModel()
        {
            var woodCache = new ResourceCache();
            _woodCache = new ObservableResourceCache(woodCache, () =>
            {
                NotifyPropertyChanged(nameof(Wood));
                NotifyPropertyChanged(nameof(Lumbermill));
            });
            Lumbermill = new Lumbermill(_woodCache);

            _loop = new GameLoop(TicksPerSecond);
            _loop.Tick += () =>
            {
                Lumbermill.Generate(1 / TicksPerSecond);
            };
            _loop.Start();

            _woodCache.Apply(20);
        }

        public Lumbermill Lumbermill { get; private set; }

        public double Wood => _woodCache.Quantity;

        public ICommand Increment => new DelegateCommand(() => { _woodCache.Apply(1); });

        public ICommand UpgradeLumbermill => new DelegateCommand(() => { Lumbermill.Upgrade(); });
    }
}
