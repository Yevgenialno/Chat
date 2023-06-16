using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using chat.Models;
using chat.Services;

namespace chat.Pages
{
    public class ChooseDialogModel : PageModel
    {
		public User? userLoginned { get; set; }
		public IQueryable<User>? startedDialogs { get; set; }
        public void OnGet()
        {
		}
		public IActionResult? OnGetUserLoginned(User user)
		{
			if (LoginService.CheckLoginPassword(user.Tag, user.Password) is not null)
			{
				TempData["UserTag"] = user.Tag;
				TempData["UserPassword"] = user.Password;
				userLoginned = user;
				startedDialogs = messageService.GetUsersStartedDialog(userLoginned);
				return null;
			}
			else
				return RedirectToPage("Index");
		}

		public IActionResult OnPost(string tag)
		{
			return RedirectToPage("dialog", "DialogChosen", new { userTag = (string)TempData["UserTag"] , userPassword = (string)TempData["UserPassword"] , addresseeTag = tag});
		}
	}
}
