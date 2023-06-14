using chat.Models;

namespace chat.Services;

public static class messageService
{
    static List<Message> dialog{get;}
    static int length = 2;
    static messageService()
    {
        dialog = new List<Message>
        {
            new Message{Content="m1"},
            //new message{Id=0, Content="m1", Time="00:01"},
            //new message{Id=1, Content="m2", Time="00:02"}
        };
    }

    public static List<Message> GetAll() => dialog;

    public static void Add(Message m)
    {
        dialog.Add(m);
        length++;
    }
}