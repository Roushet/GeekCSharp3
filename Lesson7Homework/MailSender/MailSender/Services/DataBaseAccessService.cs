using System.Collections.ObjectModel;
using System.Linq;

namespace MailSender.Services
{
    class DataBaseAccessService : IDataAccessService
    {
        //private readonly EmailsDataContext _DataContext = new EmailsDataContext();
        private MailSenderDBEntities _MailSenderEntities;

        public DataBaseAccessService()
        {
            _MailSenderEntities = new MailSenderDBEntities();
        }

        //        public ObservableCollection<emails> GetEmails() => new ObservableCollection<emails>();
        public ObservableCollection<emails> GetEmails()
        {
            ObservableCollection<emails> EmailList = new ObservableCollection<emails>();
            foreach (emails item in _MailSenderEntities.emails)
            {
                EmailList.Add(item);
            }

            return EmailList;
        }

        public int CreateEmail(emails email)
        {
            if (_MailSenderEntities.emails.Contains(email)) return email.Id;

            _MailSenderEntities.emails.Add(email);
            _MailSenderEntities.SaveChanges();
            return email.Id;
        }

        //public int CreateEmail(Email email)
        //{
        //    if (_DataContext.Email.Contains(email)) return email.Id;
        //    _DataContext.Email.InsertOnSubmit(email);
        //    _DataContext.SubmitChanges();
        //    return email.Id;
        //}
    }
}