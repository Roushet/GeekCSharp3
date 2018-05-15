using EmailSendServiceLib;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSendServiceLib.Tests
{
    [TestClass]
    public class EmailSendServiceTest
    {
        EmailSendService service;

        [TestInitialize]
        public void TestInit()
        {
            string host = "smtp.yandex.ru";
            int port = 465;
            bool ssl = true;

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential
            {
                UserName = "qweqe@yandex.ru",
                Password = "qweqwe",
            };

            service = new EmailSendService(host, port, ssl, credential);

        }

        [TestMethod(), Timeout(10000), Description("Тестирование отправки")]
        public void SendMailToAllTest()
        {
            string from = "vovanpadawan@gmail.com";
            string subject = "Test message";
            string body = "Test message body";

            List<string> addresses = new List<string> { "vovanpadawan@gmail.com" };

            try
            {
                service.SendMailToAll(from, subject, body, addresses);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.IsTrue(true);
        }

        //private static EventHandler Service_SentEvent()
        //{
        //    throw new NotImplementedException();
        //}
    }
}


