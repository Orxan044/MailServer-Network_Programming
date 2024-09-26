using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net.Mail;

namespace MailServer.Smtp;

public class Imap
{
    public  ImapClient? ImapClient { get; private set; }
    public Imap()
    {
        imapConnect();
    }


    private void imapConnect()
    {
        ImapClient = new();
        ImapClient.Connect("imap.gmail.com", 993);
        ImapClient.Authenticate("logmanquliyev33@gmail.com", "rykn paby iqnf madd");
    }

    public async void GetInbox()
    {

        

        var inbox = ImapClient!.GetFolder("Inbox");
        inbox.Open(FolderAccess.ReadOnly);

        var ids = inbox.Search(SearchQuery.All);

        //IList<string> messages = [];

        foreach (var id in ids)
        {
            var message = inbox.GetMessage(id).Subject;
            //messages.Add(message);
        }

        //return messages;
    }





}
