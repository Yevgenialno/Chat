using chat.Models;
using Microsoft.EntityFrameworkCore;

namespace chat.Services;

public static class messageService
{
    static List<Message> dialog{get;}
    static DbSet<Message> dialog2 { get; set; }
    static ChatDbContext context { get; set; }
    static int length = 2;
    static messageService()
    {
        context = new ChatDbContext();
        dialog = new List<Message>
        {
            new Message{Content="m1"},
            //new message{Id=0, Content="m1", Time="00:01"},
            //new message{Id=1, Content="m2", Time="00:02"}
        };
        //ChatDbContext context = new ChatDbContext();
        dialog2 = context.Messages;
    }

    public static List<Message> GetAll() => dialog2.ToList();

    public static void Add(Message m)
    {
        dialog.Add(m);
        //dialog2.Add(m);
        dialog2.Add(m);
        context.SaveChanges();
        length++;
    }
}