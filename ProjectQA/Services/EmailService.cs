using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQA.Services
{
    public class EmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("egor1854234245@gmail.com", "yhtiqlvmhmdibljz"),
                EnableSsl = true,
            };

            smtpClient.Send("egor1854234245@gmail.com", toEmail, subject, body);
        }
    }
}
