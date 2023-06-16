using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat.Models;

public class Message
{
    [Key]
    public int Id { get; set; }
    public DateTime SendTime{get; set;}
    [Required]
    public string? Content{get; set;}

    [ForeignKey("Sender")]
    public string SenderTag { get; set;}
    public User Sender { get; set;}

	[ForeignKey("Receiver")]
	public string ReceiverTag { get; set; }
	public User Receiver { get; set;}
}