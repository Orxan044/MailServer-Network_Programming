using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailServer.Smtp;
using System.Windows;
using System.Windows.Documents;

namespace MailServer;

public partial class MainWindow : Window
{
   // private Imap _imap = new();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnCompose_Click(object sender, RoutedEventArgs e)
    {

    }




    private void Compose()
    {

    }

    private async void BtnInbox_Click(object sender, RoutedEventArgs e)
    {
        //Task.Run(() => 
        //{
        //    //Dispatcher.Invoke(() => { ListBoxMails.Items.Clear(); });

        //    if (_imap is null) return;

        //    var messages = _imap.GetInbox();

        //    foreach ( var message in messages )
        //    {
        //        Dispatcher.Invoke(() => { ListBoxMails.Items.Add(message); });
        //    }
        //});

        var _imap = new ImapClient();
        _imap.Connect("imap.gmail.com", 993);
        _imap.Authenticate("logmanquliyev33@gmail.com", "rykn paby iqnf madd");



        var inbox = _imap!.GetFolder("Inbox");
        inbox.Open(FolderAccess.ReadOnly);

        var ids = inbox.Search(SearchQuery.All);

        //IList<string> messages = [];

        foreach (var id in ids)
        {
            ListBoxMails.Items.Add(await inbox.GetMessageAsync(id));
        }


        //var inbox = _imap!.GetFolder("Inbox");
        //inbox.Open(FolderAccess.ReadOnly);

        //var ids = inbox.Search(SearchQuery.All);

        //foreach (var id in ids)
        //{
        //    var message = inbox.GetMessage(id).Subject;
        //    Dispatcher.Invoke(() => { ListBoxMails.Items.Add(message); });
        //}

        //var messages = _imap.GetInbox();

        //foreach (var message in messages)
        //{
        //}
    }
 
}