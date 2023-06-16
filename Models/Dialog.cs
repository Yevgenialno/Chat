using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat.Models
{
	public class Dialog
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("FirstUser")]
		public string FirstUserTag { get; set; }

		[ForeignKey("SecondUser")]
		public string SecondUserTag { get; set; }
		public User FirstUser { get; set; }
		public User SecondUser { get; set; }

		public Dialog() { }

		public Dialog(User firstUser, User secondUser)
		{
			//FirstUser = firstUser;
			//SecondUser = secondUser;
		}
	}
}
