namespace MailServer.Smtp;

public class Post
{
    public string? From { get; set; }
    public string? Subject { get; set; }

    public override string ToString() => $"From -> {From} , Subject -> {Subject}";

}
