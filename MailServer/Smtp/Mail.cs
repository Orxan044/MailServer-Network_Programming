using Org.BouncyCastle.Crypto.Macs;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailServer.Smtp;

public class Mail
{

    SmtpClient Client { get; set; } = new("smtp.gmail.com",587);

    public Mail()
    {
        Client.DeliveryMethod = SmtpDeliveryMethod.Network;
        Client.EnableSsl = true;
        Client.UseDefaultCredentials = false;

        Client.Credentials = new NetworkCredential
        (
            userName: "logmanquliyev33@gmail.com",
            password: "rykn paby iqnf madd"
        );
    }

    public void SendMail(string to,string body,string subject)
    {
        Task.Run(() => 
        {

            try
            {
                var message = new MailMessage()
                {

                    Body = body,
                    Subject = subject,
                    From = new MailAddress("logmanquliyev33@gmail.com"),
                };
                message.To.Add(new MailAddress(to));
                Client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        });

    }
}
