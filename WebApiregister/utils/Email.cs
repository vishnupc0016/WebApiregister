using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApiregister.utils
{
    class EmailSend
    {
        public void SendEmail(string toAddress, string msg, string subject)
        {
           


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("vichupc@gmail.com"); // From

            mail.To.Add(msg);// To
            mail.Subject = subject;
            mail.Body = msg;


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("vichupc@gmail.com", "snakegame005");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }

}
