using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WPFSender.MVVM
{
    public class LambdaCommand : ICommand

    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        private Action<object> commandAction;
        private Func<object, bool> canExecute;

        public LambdaCommand(Action<object> CommandAction, Func<object, bool> CanExecute =null)
        {
            commandAction = CommandAction;
            canExecute = CanExecute;
        }
    }
}
