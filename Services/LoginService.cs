using chat.Models;
using Microsoft.EntityFrameworkCore;

namespace chat.Services
{
	public static class LoginService
	{
		private static ChatDbContext context;
		private static DbSet<User> users;

		static LoginService()
		{
			context = new ChatDbContext();
			users = context.Users;
		}
		public static User? CheckLoginPassword(string login, string password)
		{
			return users.FirstOrDefault(u => u.Tag == login && u.Password == password);
		}

		public static void Register(string userTag, string userPassword)
		{
			User newUser = new User(userTag, userPassword);
			users.Add(newUser);
			context.SaveChanges();
		}

		public static bool UserExists(string tag)
		{
			return users.SingleOrDefault(u => u.Tag == tag) is not null;
		}
	}
}
