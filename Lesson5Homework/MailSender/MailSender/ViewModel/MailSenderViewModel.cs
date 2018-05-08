using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Services;
using EmailSendServiceLib;
using System.Windows.Documents;

namespace MailSender.ViewModel
{
    public class MailSenderViewModel : ViewModelBase
    {
        private IDataAccessService _DataService;

        private ObservableCollection<Email> _Emails = new ObservableCollection<Email>();

        public ObservableCollection<Email> Emails
        {
            get => _Emails;
            set
            {
                if (!Set(ref _Emails, value)) return;
                _EmailsView = new CollectionViewSource { Source = value };
                _EmailsView.Filter += OnEmailsCollectionViewSourceFilter;
                RaisePropertyChanged(nameof(EmailsView));
            }
        }

        private CollectionViewSource _EmailsView;
        public ICollectionView EmailsView => _EmailsView?.View;

        private Email _CurrentEmail = new Email();

        public Email CurrentEmail
        {
            get => _CurrentEmail;
            set => Set(ref _CurrentEmail, value);
        }

        //пропертя для заголовка, работает в одну сторону
        private string _Header;

        public string Header
        {
            get => _Header;
            set => Set(ref _Header, value);
        }

        //пропертя для сервера
        private KeyValuePair<string, int> _CurrentServer;

        public KeyValuePair<string, int> CurrentServer
        {
            get => _CurrentServer;
            set => Set(ref _CurrentServer, value);
        }

        //пропертя для документа
        private string _Document;

        public string Document
        {
            get => _Document;
            set => Set(ref _Document, value);
        }

        private string _FilterName;

        public string FilterName
        {
            get => _FilterName;
            set
            {
                if (!Set(ref _FilterName, value)) return;
                EmailsView.Refresh();
            }
        }

        public RelayCommand ReadAllMailsCommand { get; }
        public RelayCommand<Email> SaveEmailCommand { get; }

        //команда отправки сообщения
        public RelayCommand SendMailCommand { get; }

        public MailSenderViewModel(IDataAccessService data_service)
        {
            _DataService = data_service;

            ReadAllMailsCommand = new RelayCommand(GetEmails);
            SaveEmailCommand = new RelayCommand<Email>(SaveEmail);

            //реализация команды отправки
            SendMailCommand = new RelayCommand(SendEmail);
        }

        private void SendEmail()
        {
            //1. Сервер
            //2. Отправитель логин пароль для креденшелов - CurrentEmail
            //3. Заголовок и тело


            string name = CurrentEmail.Name;
            string pass;
            bool tryPass = SendersDB.Senders.TryGetValue(name, out pass);

            //CurrentServer
            int port;
            port = CurrentServer.Value;
            //bool tryPort = SendersDB.Servers.TryGetValue(CurrentServer, out port);


            EmailSendService service = new EmailSendService(CurrentServer.Key, port, true, new System.Net.NetworkCredential(name, pass));
            //получаю лист адресов для рассылки
            List<string> emails = Emails.Select(e => e.Address).ToList<string>();

            try
            {
                service.SendMailToAll(CurrentEmail.Address, Header, Document, emails);

            }
            catch(Exception e)
            {
                Debug.Write("Send mail Exception: " + e.Message + " " + e.Source);
            }
        }

        private void GetEmails() => Emails = _DataService.GetEmails();

        private void SaveEmail(Email email)
        {
            email.Id = _DataService.CreateEmail(email);
            if (email.Id == 0) return;
            Emails.Add(email);
        }

        private void OnEmailsCollectionViewSourceFilter(object Sender, FilterEventArgs E)
        {
            if (!(E.Item is Email email) || string.IsNullOrWhiteSpace(_FilterName)) return;
            if (!email.Name.Contains(_FilterName))
                E.Accepted = false;
        }
    }
}
