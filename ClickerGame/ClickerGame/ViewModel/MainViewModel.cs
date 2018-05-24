using MvvmUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private Int32 _wood;

        public Int32 Wood
        {
            get { return _wood; }
            set
            {
                if (_wood == value) return;
                _wood = value;
                NotifyPropertyChanged();
            }
        }
    }
}