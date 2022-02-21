using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderExample
{
    static class EmailSender
    {
        public static void Send(string to, string message)
        {//Email gönderme operasyonu
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";//google oldupu için
            smtpClient.Port = 587;//google kullanıyorsak
            smtpClient.EnableSsl = true;

            NetworkCredential credential = new NetworkCredential("alisarirabbitmq@gmail.com", "256qrt652");//Kullanıcı bilgilerini gircez
            smtpClient.Credentials = credential;

            MailAddress gonderen = new MailAddress("alisarirabbitmq@gmail.com", "Ali SARI Example"); //Gönderen kişi
            MailAddress alici = new MailAddress(to);//to parametresine gelen kişi alıcı olacak

            MailMessage mail = new MailMessage(gonderen, alici);
            mail.Subject = "SignalR Rabbitmq example"; //Girilecek konu
            mail.Body = message;

            smtpClient.Send(mail);



             
        }
    }
}
