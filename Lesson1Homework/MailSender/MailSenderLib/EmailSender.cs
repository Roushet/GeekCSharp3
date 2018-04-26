using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    public class EmailSender
    {
        SmtpClient _client;

        public EmailSender(NetworkCredential credentials)
        {
            _client = new SmtpClient(Settings.Server, Settings.Port) { EnableSsl = true, Credentials = credentials };
        }

        public void SendMail(MailMessage message, string address)
        {
            try
            {
                _client.Send(message);

            }
            catch (SmtpException error)
            {

            }
        }

        public void SendMailToList(MailMessage message, List<string> addresses)
        {
            foreach (var item in addresses)
                SendMail(message, item);
        }

    }
}
