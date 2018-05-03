using System.Collections.ObjectModel;
using System.Linq;

namespace MailSender.Services
{
    class DataBaseAccessService : IDataAccessService
    {
        private readonly EmailsDataContext _DataContext = new EmailsDataContext();

        public ObservableCollection<Email> GetEmails() => new ObservableCollection<Email>(_DataContext.Email);

        public int CreateEmail(Email email)
        {
            if (_DataContext.Email.Contains(email)) return email.Id;
            _DataContext.Email.InsertOnSubmit(email);
            _DataContext.SubmitChanges();
            return email.Id;
        }
    }
}