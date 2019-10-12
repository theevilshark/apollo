using System;
using System.Windows.Input;

namespace MvvmUtilities
{
    public class DelegateCommandFactory
    {
        public ICommand CreateFor(Action action) => new DelegateCommand(action);
    }
}
