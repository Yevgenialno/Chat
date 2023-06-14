using chat.Models;
using Microsoft.EntityFrameworkCore;

namespace chat.Services
{
	public static class LoginService
	{
		private static DbSet<User> users;

		static LoginService()
		{
			ChatDbContext context = new ChatDbContext();
			users = context.Users;
		}
		public static User? CheckLoginPassword(string login, string password)
		{
			return users.FirstOrDefault(u => u.Tag == login && u.Password == password);
		}
	}
}
