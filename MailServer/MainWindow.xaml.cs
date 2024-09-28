using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailServer.Smtp;
using System.Windows;
using System.Windows.Documents;

namespace MailServer;

public partial class MainWindow : Window
{
    private Imap _imap = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnCompose_Click(object sender, RoutedEventArgs e)
    {
        var window = new ComposeWindow();
        window.ShowDialog();
    }

    private async void BtnInbox_Click(object sender, RoutedEventArgs e)
    {

        var folder = _imap.ImapClient!.GetFolder("Inbox");
        await folder.OpenAsync(FolderAccess.ReadOnly);

        var ids = await folder.SearchAsync(SearchQuery.All);

        foreach (var id in ids)
        {
            var message = await folder.GetMessageAsync(id);
            var post = new Post()
            {
                From = message.From.ToString(),
                Subject = message.Subject.ToString()
            };

            ListBoxMails.Items.Add(post);

        }
    }

    private async void BtnStarred_Click(object sender, RoutedEventArgs e)
    {
        var folder = _imap.ImapClient!.GetFolder(SpecialFolder.Flagged);
        await folder.OpenAsync(FolderAccess.ReadOnly);

        var ids = await folder.SearchAsync(SearchQuery.All);

        foreach (var id in ids)
        {
            var message = await folder.GetMessageAsync(id);
            var post = new Post()
            {
                From = message.From.ToString(),
                Subject = message.Subject.ToString()
            };

            ListBoxMails.Items.Add(post);

        }
    }

    private async void BtnSent_Click(object sender, RoutedEventArgs e)
    {
        ListBoxMails.Items.Clear();
        var folder = _imap.ImapClient!.GetFolder(SpecialFolder.Sent);
        await folder.OpenAsync(FolderAccess.ReadOnly);

        var ids = await folder.SearchAsync(SearchQuery.All);

        foreach (var id in ids)
        {
            var message = await folder.GetMessageAsync(id);
            var post = new Post()
            {
                From = message.From.ToString(),
                Subject = message.Subject.ToString()
            };

            ListBoxMails.Items.Add(post);

        }
    }

    private async void BtnDrafts_Click(object sender, RoutedEventArgs e)
    {
        var folder = _imap.ImapClient!.GetFolder(SpecialFolder.Drafts);
        await folder.OpenAsync(FolderAccess.ReadOnly);

        var ids = await folder.SearchAsync(SearchQuery.All);

        foreach (var id in ids)
        {
            var message = await folder.GetMessageAsync(id);
            var post = new Post()
            {
                From = message.From.ToString(),
                Subject = message.Subject.ToString()
            };

            ListBoxMails.Items.Add(post);

        }
    }
}