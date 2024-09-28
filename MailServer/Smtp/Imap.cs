using MailKit.Net.Imap;

namespace MailServer.Smtp;

public class Imap
{
    public ImapClient? ImapClient { get; private set; }
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
    
}
