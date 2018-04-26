using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using MailSenderLib;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            //const string server = "smtp.yandex.ru";

            var user = UserNameTextBox.Text;
            var pass = PasswordEdit.Password;

            string from = user + "@yandex.ru";
            const string to = "vovanpadawan@gmail.com";

            EmailSender mailSender = new EmailSender(new NetworkCredential(user, pass));

            var message = new MailMessage(from, to, "Test message", "Test message body");

            mailSender.SendMail(message, to);

            //try
            //{
            //    using (var message = new MailMessage(from, to, "Test message", "Test message body"))
            //    using (var client = new SmtpClient(Settings.Server, Settings.Port) { EnableSsl = true, Credentials = new NetworkCredential(user, pass)})
            //    {
            //        client.Send(message);
            //    }
            //}
            //catch (SmtpException error)
            //{
            //    //MessageBox.Show(error.Message, "При отправке сообщения возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    var dlg = new MessageSendCompletedDlg();
            //    dlg.ShowDialog();
            //}
        }

    }
}
