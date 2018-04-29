using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    static class MailSenders
    {
        public static Dictionary<string, string> Senders { get; } = new Dictionary<string, string>
        {
            { "qwe@ads.ru", Encryptor.Decrypt("1234l;i") },
            { "zxc@rty.ru", Encryptor.Decrypt(";liq34tjk") },
        };
    }
}
