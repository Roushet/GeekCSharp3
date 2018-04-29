using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class EmailSender
    {
        SmtpClient _client;

        public EmailSender(NetworkCredential credentials)
        {
            //_client = new SmtpClient(Settings.Server, Settings.Port) { EnableSsl = true, Credentials = credentials };
        }

        public void SendMail(MailMessage message)
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
            {
                MailMessage messageToSend = new MailMessage(message.From.ToString(),
                                                            item, message.Headers[0].ToString(),
                                                            message.Body
                                                                        );
                SendMail(message);

            }
        }

    }
}
