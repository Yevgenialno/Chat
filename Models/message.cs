using System.ComponentModel.DataAnnotations;

namespace chat.Models;

public class message
{
    //public int Id{get; set;}
    //public string? Time{get; set;}
    [Required]
    public string? Content{get; set;}
    /*public message(string c)
    {
        this.Id = 0;
        this.Content = c;
        this.Time = "00:00";
    }

    public message(string c, string t, int i)
    {
        this.Id = i;
        this.Content = c;
        this.Time = t;
    }*/
}