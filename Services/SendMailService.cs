using MimeKit;
using MailKit.Security;
using Microsoft.Extensions.Options;

public class SendMailService
{
    MailSetting _mailSetting { set; get; }
    public SendMailService(IOptions<MailSetting> mailSetting)
    {
        _mailSetting = mailSetting.Value;
    }
    public async Task<string> SendMail(MailContent mailContent)
    {
        var email = new MimeMessage();

        email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
        email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
        email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
        email.Subject = mailContent.Subject;

        var builder = new BodyBuilder();

        builder.HtmlBody = mailContent.Body;
        email.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            await smtp.ConnectAsync(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);
            await smtp.SendAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return  "Gửi thất bại. Lỗi:" + e.Message;
        }

        smtp.Disconnect(true);
        return "Gửi thành công";
    }
}
public class MailContent
{
    public string To { set; get; }
    public string Subject { set; get; }
    public string Body { set; get; }

}