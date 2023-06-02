using System.Net;
using System.Net.Mail;

namespace MailUltis
{
    public class MailUltis
    {
        // Gửi bằng local (Linux)
        public static async Task<string> SendMail(string _form, string _to, string _subject, string _body)
        {
            MailMessage message = new MailMessage(_form, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_form));
            message.Sender = new MailAddress(_form);

            using var smtpClient = new SmtpClient("localhost");

            try
            {
                await smtpClient.SendMailAsync(message);
                return "Email sent";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Gửi Email thất bại T.T";
            }
        }
        // Gửi bằng Gmail
        public static async Task<string> SendGmail(string _form, string _to, string _subject, string _body, string _gmail, string _password)
        {
            MailMessage message = new MailMessage(_form, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_form));
            message.Sender = new MailAddress(_form);

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_gmail, _password);
            try
            {
                await smtpClient.SendMailAsync(message);
                return "Email sent";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Gửi Email thất bại T.T";
            }
        }
    }
}
// dotnet add package MailKit
// dotnet add package MimeKit