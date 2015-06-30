namespace Common
{
    using System;
    using System.Configuration;
    using System.Net.Mail;

    public class Mail
    {
        public string SendEmail( string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            var senderPassword = ConfigurationManager.AppSettings["SenderPassword"]; // sender password here…
            var fromAddress = ConfigurationManager.AppSettings["FromAddress"]; // sender password here…
            try
            {
                var smtp = new SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["SMTPServer"],
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(fromAddress, senderPassword),
                    Timeout = 30000,
                };
                var message = new MailMessage(fromAddress, toAddress, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }
            return result;
        }
    }
}
