using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace MailSender
{
    class ApplicationCloseCommand : MarkupExtension, ICommand
    {
        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider sp) => this;

        private event EventHandler _CanExecuteChanged;

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged
        {
            add
            {
                _CanExecuteChanged += value;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                _CanExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <inheritdoc />
        public void Execute(object parameter) => Application.Current.Shutdown(parameter as int? ?? 0);

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            if (parameter != null && parameter is int code && code < 0) return false;

            return App.CanShutdownCommandExecuted;
        }

        public void CheckCanExecute() => _CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class ChangeAppStateCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.CanShutdownCommandExecuted ^= true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
