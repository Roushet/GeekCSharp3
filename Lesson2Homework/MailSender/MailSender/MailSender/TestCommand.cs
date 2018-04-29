using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender
{
    class CommandTest : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public CommandTest(Action<object> action)
        {
            _execute = action;
        }

        private Action<object> _execute;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
