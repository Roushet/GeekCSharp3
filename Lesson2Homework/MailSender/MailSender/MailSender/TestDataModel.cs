using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MailSender
{
    class TestDataModel : ViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        private string _Data = "3.14159265";

        public ICommand TestCommand { get; set; }


        public TestDataModel()
        {
            TestCommand = new CommandTest(ExecTest);
        }

        private void ExecTest(object obj)
        {
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();

            //эпический колхоз

            MainWindow window = Application.Current.MainWindow as MainWindow;
            var item = window.SelectedItem();

            credential.UserName = "";
            credential.Password = "";

            EmailSender sender = new EmailSender(credential);
        }


        public string Data
        {
            get => _Data;
            set
            {
                _Data = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DataLength));
            }
        }

        public int DataLength => _Data.Length;
    }

    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
