namespace Common
{
    using System;
    using System.Net.Mail;

    public class Mail
    {
        public string SendEmail(string fromAddress, string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            const string senderPassword = "Password"; // sender password here…
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
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
