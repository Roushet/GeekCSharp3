using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
    public interface IDataAccessService
    {
        //ObservableCollection<Email> GetEmails();
        ObservableCollection<emails> GetEmails();

        //int CreateEmail(Email email);
        int CreateEmail(emails email);
    }
}
