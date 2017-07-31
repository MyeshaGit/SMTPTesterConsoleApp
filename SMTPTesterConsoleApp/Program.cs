using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

/// <summary>
/// This sample is a simple console app that uses SMTP relay to send a message through O365. 
/// </summary>
namespace SMTPTesterConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("Sender@domain.com");
           
            message.To.Add(new MailAddress("Recipient1@domain.com"));
            message.To.Add(new MailAddress("Recipient2@domain.com"));


            message.Subject = "This is the subject " + DateTime.Now;
            message.Body = "This is the body content";

            //Unsubscribe header:    https://www.ietf.org/rfc/rfc2369.txt
            message.Headers.Add("List-Unsubscribe", "<mailto:unsubscriberapp@domain.com?subject=unsubscribe>");


            //Configure SMTP client to send mail - https://support.office.com/en-us/article/POP-and-IMAP-settings-for-Outlook-Office-365-for-business-7fc677eb-2491-4cbc-8153-8e7113525f6c

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("Sender@domain.com", "Password");
            client.Host = "smtp.office365.com";
            client.Port = 25;
            client.EnableSsl = true; 
            client.Send(message);
            Console.WriteLine("All went well!");
            Console.Read();

        }
    }
}
