using chat.Migrations;
using chat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace chat.Services;

public static class messageService
{
    private static List<Message> dialog{get;}
    private static DbSet<Message> AllMessages { get; set; }
    //private static DbSet<User> StartedDialogUsers { get; set; }
    static ChatDbContext context { get; set; }
    static messageService()
    {
        context = new ChatDbContext();
        dialog = new List<Message>
        {
            new Message{Content="m1"}
        };
        AllMessages = context.Messages;
    }

    //public static List<Message> GetAll() => dialog2.ToList();

    public static List<Message> GetDialog(string tag1, string tag2)
    {
        return AllMessages.Where(m => (m.Sender.Tag == tag1 && m.Receiver.Tag == tag2) || (m.Sender.Tag == tag2 && m.Receiver.Tag == tag1)).OrderBy(m => m.SendTime).Take(10).ToList();
    }

    public static void Add(string content, string senderTag, string senderPassword, string receiverTag)
    {
        Message m = new Message
        {
            Content = content,
            SendTime = DateTime.Now,
            SenderTag = senderTag,
            ReceiverTag = receiverTag
        };
        AllMessages.Add(m);
        context.SaveChanges();
    }

    public static bool DialogExists(string tag1, string tag2) => !context.StartedDialogs.Where(d => d.FirstUser.Tag == tag1 && d.SecondUser.Tag == tag2).IsNullOrEmpty();

    public static IQueryable<User> GetUsersStartedDialog(User u) => context.StartedDialogs.Where(d => d.FirstUser == u).Select(d => d.SecondUser);

    public static void StartDialog(string tag1, string tag2)
    {
        context.StartedDialogs.Add(new Dialog { FirstUserTag = tag1, SecondUserTag = tag2 });
		context.StartedDialogs.Add(new Dialog { FirstUserTag = tag2, SecondUserTag = tag1 });
		context.SaveChanges();
    }
}