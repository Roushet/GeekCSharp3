using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Collections.ObjectModel;

namespace EmailSendServiceLib
{
    public sealed class EmailSendService : IDisposable
    {
        SmtpClient _client;

        /// <summary>
        /// Конструктор класса, принимает параметры для создания почтового клиента, 
        /// а так же данные по отправителю письма, могут быть нулл
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="ssl"></param>
        /// <param name="credential"></param>
        public EmailSendService(string host, int port, bool ssl, NetworkCredential credential)
        {
            _client = new SmtpClient(host, port) { EnableSsl = ssl, Credentials = credential };
        }

        private EmailSendService() { }


        private void SendMailAsync(MailMessage message)
        {
            _client.SendAsync(message, null);
        }

        public void SendMailToAll(string from, string subject, string body, List<string> addresses)
        {
            foreach(string address in addresses)
            {
                MailMessage message = new MailMessage(from, address, subject, body);
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }

    }
}
