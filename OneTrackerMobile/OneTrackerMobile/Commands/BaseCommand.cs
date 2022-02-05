using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OneTrackerMobile.Commands
{
    public class BaseCommand : ICommand
    {
        private readonly Action _command;
        private readonly Func<bool> _canExecute;

        public BaseCommand(Action command, Func<bool> canExecute = null)
        {
            _canExecute = canExecute;
            _command = command ?? throw new ArgumentNullException("command");
        }

        public void Execute(object parameter)
        {
            _command();
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute();

        }
        private void SomethingHappen()
        {
            this.CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler CanExecuteChanged;
    }
}
