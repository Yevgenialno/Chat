using System.ComponentModel.DataAnnotations;

namespace chat.Models
{
	public class Dialog
	{
		[Key]
		public int Id { get; set; }
		public User FirstUser { get; set; }
		public User SecondUser { get; set; }

		public Dialog() { }

		public Dialog(User firstUser, User secondUser)
		{
			FirstUser = firstUser;
			SecondUser = secondUser;
		}
	}
}
