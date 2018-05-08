using System;
using System.Collections.ObjectModel;

namespace MailSender.Services
{
    class XmlFileAccessService : IDataAccessService 
    {
        public ObservableCollection<Email> GetEmails() => throw new NotImplementedException();

        public int CreateEmail(Email email) => throw new NotImplementedException();
    }
}