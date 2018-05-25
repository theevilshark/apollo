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
        private DispatcherTimer _timer;
        private Int32 _loggers;
        private Int32 _wood;
        private Boolean _canPurchaseLogger;

        public MainViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(Object sender, EventArgs e)
        {
            Wood += _loggers;
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
        public Int32 Wood
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