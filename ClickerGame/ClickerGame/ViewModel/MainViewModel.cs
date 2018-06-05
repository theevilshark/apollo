using ClickerGame.Buildings;
using ClickerGame.Processing;
using MvvmUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClickerGame.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private const Double TicksPerSecond = 1;
        private const Double GrowthInterval = 5;

        private Double _wood;
        private Boolean _canUpgradeLumbermill;

        private Lumbermill _lumbermill;
        private GameLoop _loop;

        public MainViewModel()
        {
            _lumbermill = new Lumbermill();

            _loop = new GameLoop(TicksPerSecond);
            _loop.Tick += () => Wood += (_lumbermill.Level / (TicksPerSecond * GrowthInterval));
            _loop.Start();

            Wood = 20;
            CanUpgradeLumbermill = Wood >= _lumbermill.UpgradeCost;
        }

        public Lumbermill Lumbermill => _lumbermill;

        public Boolean CanUpgradeLumbermill
        {
            get { return _canUpgradeLumbermill; }
            set
            {
                if (_canUpgradeLumbermill == value) return;
                _canUpgradeLumbermill = value;
                NotifyPropertyChanged();
            }
        }
        public Double Wood
        {
            get { return _wood; }
            set
            {
                if (_wood == value) return;
                _wood = value;
                NotifyPropertyChanged();
                CanUpgradeLumbermill = Wood >= _lumbermill.UpgradeCost;
            }
        }

        public ICommand Increment => new DelegateCommand(() => Wood++);
        public ICommand UpgradeLumbermill => new DelegateCommand(() =>
        {
            Lumbermill.Upgrade();
            Wood -= _lumbermill.UpgradeCost;
            NotifyPropertyChanged("Lumbermill");
        });
    }
}