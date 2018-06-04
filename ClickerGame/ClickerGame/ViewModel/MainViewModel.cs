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
        private const Double LoggerInterval = 5;

        private Int32 _loggers;
        private Double _wood;
        private Boolean _canPurchaseLogger;

        private GameLoop _loop;

        public MainViewModel()
        {
            _loop = new GameLoop(TicksPerSecond);
            _loop.Tick += _loop_Tick;
            _loop.Start();
        }

        private void _loop_Tick()
        {
            Wood += (_loggers / (TicksPerSecond * LoggerInterval));
        }

        public Boolean CanPurchaseLogger
        {
            get { return _canPurchaseLogger; }
            set
            {
                if (_canPurchaseLogger == value) return;
                _canPurchaseLogger = value;
                NotifyPropertyChanged();
            }
        }
        public Int32 Loggers
        {
            get { return _loggers; }
            set
            {
                if (_loggers == value) return;
                _loggers = value;
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
                CanPurchaseLogger = _wood >= 10;
            }
        }

        public ICommand Increment => new DelegateCommand(() => Wood++);
        public ICommand PurchaseLogger => new DelegateCommand(() => { Loggers++; Wood -= 10; });
    }
}