using MailServer.Smtp;
using System.Windows;
namespace MailServer;

public partial class ComposeWindow : Window
{
    public ComposeWindow()
    {
        InitializeComponent();
    }

    private void btnSend_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var to = txtBoxTo.Text;
            var subject = txtBoxSubject.Text;
            var body = txtBoxBody.Text;

            var mailServer = new Mail();
            mailServer.SendMail(to, body, subject);

            MessageBox.Show("Send Message");
        }
        catch (Exception)
        {
            throw;
        }


    }
}
