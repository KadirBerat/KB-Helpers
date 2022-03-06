using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KB.Helpers
{
    public static class MailHelper
    {
        public static async Task MailSend(string senderMail, List<string> recipients, string subject, string message, string senderPassword, int port, string host, bool ssl)
        {
            MailMessage eMail = new MailMessage();
            if (!String.IsNullOrEmpty(senderMail))
                eMail.From = new MailAddress(senderMail);
            if (recipients.Count > 0)
            {
                foreach (var recipient in recipients)
                {
                    string rcp = recipient.ToString();
                    if (rcp.Contains("@") == true && (rcp.Contains(".com") || rcp.Contains(".net")))
                        eMail.To.Add(rcp);
                }
            }
            if (!String.IsNullOrEmpty(subject))
                eMail.Subject = subject;
            if (!String.IsNullOrEmpty(message))
                eMail.Body = message;
            SmtpClient smtp = new SmtpClient();
            if (!String.IsNullOrEmpty(senderMail) && !String.IsNullOrEmpty(senderPassword))
                smtp.Credentials = new System.Net.NetworkCredential(senderMail, senderPassword);
            smtp.Port = port;
            if (!String.IsNullOrEmpty(host))
                smtp.Host = host;
            smtp.EnableSsl = ssl;
            try
            {
                await Task.Run(() => smtp.SendAsync(eMail, null));
            }
            catch (Exception ex_1)
            {
                Console.WriteLine(ex_1.Message);
                try
                {
                    await Task.Run(() => smtp.SendAsync(eMail, null));
                }
                catch (Exception ex_2)
                {
                    Console.WriteLine(ex_2.Message);
                }
            }
        }
    }
}
