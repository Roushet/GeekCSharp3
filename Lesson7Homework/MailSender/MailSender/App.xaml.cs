using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static bool sf_CanShutdownCommandExecuted = false;

        public static bool CanShutdownCommandExecuted
        {
            get => sf_CanShutdownCommandExecuted;
            set
            {
                if(sf_CanShutdownCommandExecuted == value) return;
                sf_CanShutdownCommandExecuted = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
