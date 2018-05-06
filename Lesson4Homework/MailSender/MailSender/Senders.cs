using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PasswordDataLib;

namespace MailSender
{
    static class SendersDB
    {
         public static Dictionary<string, string> Senders { get; } = new Dictionary<string, string>
         {
             { "adasd", "adasda" },
             { "zxc@qwe.ru", Encrypter.Deencrypt(";liq34tjk") },
         };

        public static Dictionary<string, int> Servers { get; } = new Dictionary<string, int>
         {
             { "smtp.yandex.ru", 25 },
             { "smtp.mail.ru", 25 }
         };

    }

    //static class Encrypter
    //{
    //    public static string Encrypt(string str, int key = 1)
    //    {
    //        return new string(str.Select(c => (char)(c + key)).ToArray());
    //    }

    //    public static string Deencrypt(string str, int key = 1)
    //    {
    //        return new string(str.Select(c => (char)(c - key)).ToArray());
    //    }
    //}
}
