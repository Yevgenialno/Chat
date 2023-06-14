using chat.Models;
using Microsoft.EntityFrameworkCore;

namespace chat.Services;

public static class messageService
{
    private static List<Message> dialog{get;}
    private static DbSet<Message> dialog2 { get; set; }
    //private static DbSet<User> StartedDialogUsers { get; set; }
    static ChatDbContext context { get; set; }
    static int length = 0;
    static messageService()
    {
        context = new ChatDbContext();
        dialog = new List<Message>
        {
            new Message{Content="m1"}
        };
        dialog2 = context.Messages;
    }

    public static List<Message> GetAll() => dialog2.ToList();

    public static void Add(Message m)
    {
        dialog.Add(m);
        dialog2.Add(m);
        context.SaveChanges();
        length++;
    }

    //public static List<User> GetUsersStartedDialog() => 
}