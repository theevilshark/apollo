using ClickerGame.Processing;
using MvvmUtilities;
using ResourceManagement;
using ResourceManagement.Buildings;
using System.Windows.Input;

namespace ClickerGame.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly DelegateCommandFactory _commandFactory;
        private readonly IResourceCache _woodCache;
        private readonly GameLoop _loop;

        public MainViewModel()
        {
            var adjustmentFactory = new ResourceAdjustmentFactory();
            _commandFactory = new DelegateCommandFactory();

            _woodCache = new ObservableResourceCache(new ResourceCache(), () =>
            {
                NotifyPropertyChanged(nameof(Wood));
                NotifyPropertyChanged(nameof(Lumbermill));
            });
            Lumbermill = new Lumbermill(_woodCache, adjustmentFactory);

            Increment = _commandFactory.CreateFor(
                () => _woodCache.Apply(adjustmentFactory.CreateIncreaseEqualTo(1)));
            UpgradeLumbermill = _commandFactory.CreateFor(Lumbermill.Upgrade);

            _loop = new GameLoop(ticksPerSecond: 100);
            _loop.Tick += (tickDuration) =>
            {
                Lumbermill.Generate(tickDuration);
            };
            _loop.Start();

            _woodCache.Apply(adjustmentFactory.CreateIncreaseEqualTo(20));
        }

        public Lumbermill Lumbermill { get; private set; }

        public decimal Wood => _woodCache.Quantity;

        public ICommand Increment { get; }

        public ICommand UpgradeLumbermill { get; }
    }
}
