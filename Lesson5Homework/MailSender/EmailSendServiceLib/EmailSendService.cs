using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EmailSendServiceLib
{

    public sealed class EmailSendService 
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
            _client.SendCompleted += _client_SendCompleted;
            _client.Timeout = 5000;
        }

        private void _client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Debug.Write("Mail send error: "  + e.Error.ToString());
                return;
            }

            if (e.Cancelled)
            {
                Debug.Write("Mail send cancelled!! ");
                return;
            }

            Debug.Write("Success: mail sent!!");
        }

        private EmailSendService() { }


        //Убрал асинхронную отправку
        private void SendMail(MailMessage message)
        {
            _client.Send(message);
        }

        public void SendMailToAll(string from, string subject, string body, List<string> addresses)
        {
            foreach(string address in addresses)
            {
                MailMessage message = new MailMessage(from, address, subject, body);
                SendMail(message);
            }
        }

    }
}
