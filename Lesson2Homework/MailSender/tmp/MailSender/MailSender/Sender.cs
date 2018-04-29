using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    class Sender
    {
        private string _Login;
        private string _Password;
        private string _Server = "smtp.yandex.ru";
        private int _Port = 25;
        private string _MessageBody;
        private string _MessageSubject;
        public ​​Sender(​string login, string pwd)
        {
            _Login = login;
            _Password = pwd;
        }

        private void Send(string mail, string name)
        {
            using (var message = new MailMessage(_Login, mail))
            {
                message.Subject = _MessageSubject;
                message.Body = _MessageBody;
                message.IsBodyHtml = false;
                using (var client = new SmtpClient(_Server, _Port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_Login, _Password);
                    try
                    {
                        client.Send(message);
                    }
                    catch (SmtpException error)
                    {
                        MessageBox.Show(error.Message, "Ошибка отправки сообщения");
                    }
                }
            }
        }

        public void Send(IQueryable<Emails> emails)
        {
            foreach (var email in emails)
            {
                Send(email.Email, email.Name);
            }
        }
    }
}
