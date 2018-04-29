using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    static class Database
    {
        private static EmailsDataContext f_EmailsDataContext = new EmailsDataContext();

        public static IQueryable<Emails> Emails => from mail in f_EmailsDataContext.Emails select mail;
    }
}
