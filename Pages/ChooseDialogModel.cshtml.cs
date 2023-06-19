using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using chat.Models;
using chat.Services;
using Azure;

namespace chat.Pages
{
    public class ChooseDialogModel : PageModel
    {
		public User? userLoginned { get; set; }
		public string LoginMessage { get; set; }

		[BindProperty]
		public string NewDialogAddresseeTag { get; set; }
		public IQueryable<User>? startedDialogs { get; set; }
        public void OnGet()
        {
		}
		public IActionResult? OnGetUserLoginned(User user)
		{
			if (LoginService.CheckLoginPassword(user.Tag, user.Password) is not null)
			{
				LoginMessage = $"Loginned succesfully as {user.Tag}";
				TempData["UserTag"] = user.Tag;
				TempData["UserPassword"] = user.Password;
				userLoginned = user;
				startedDialogs = messageService.GetUsersStartedDialog(userLoginned);
				return null;
			}
			else
				return RedirectToPage("Index");
		}

		public IActionResult? OnGetUserRegistered(User user)
		{
            if (LoginService.CheckLoginPassword(user.Tag, user.Password) is not null)
            {
				LoginMessage = $"Registered succesfully as {user.Tag}";
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

		public IActionResult OnPostCreateDialog()
		{
			if(messageService.DialogExists((string)TempData["UserTag"], NewDialogAddresseeTag))
			{
				return RedirectToPage("dialog", "DialogChosen", new { userTag = (string)TempData["UserTag"], userPassword = (string)TempData["UserPassword"], addresseeTag = NewDialogAddresseeTag });
			}
			else
			{
				if (LoginService.UserExists(NewDialogAddresseeTag))
				{
					messageService.StartDialog((string)TempData["UserTag"], NewDialogAddresseeTag);
					return RedirectToPage("dialog", "DialogChosen", new { userTag = (string)TempData["UserTag"], userPassword = (string)TempData["UserPassword"], addresseeTag = NewDialogAddresseeTag });
				}
				else
				{
					LoginMessage = "This user doesn`t exist";
					return Page();
				}
			}
		}

		public IActionResult OnPostLogOut()
		{
			return RedirectToPage("index");
		}
	}
}
