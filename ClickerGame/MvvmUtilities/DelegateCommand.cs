using System;
using System.Windows.Input;

namespace MvvmUtilities
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public Boolean CanExecute(Object parameter) => true;

        public void Execute(Object parameter) => _action();

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
    }
}