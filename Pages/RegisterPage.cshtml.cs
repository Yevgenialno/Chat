using chat.Models;
using chat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace chat.Pages
{
    public class RegisterPageModel : PageModel
    {
        public string LoginMesage { get; set; }

        [BindProperty]
        public string userTag { get; set; }

        [BindProperty]
        public string userPassword { get; set; }

        [BindProperty]
        public string userPasswordConfirm { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(userPassword != userPasswordConfirm)
            {
                LoginMesage = "Passwords doesn`t match";
                return Page();
            }
            ChatDbContext context = new ChatDbContext();
            if(context.Users.Select(u => u.Tag).Contains(userTag))
            {
                LoginMesage = "This username already exists";
                return Page();
            }
            LoginService.Register(userTag, userPassword);
            return RedirectToPage("ChooseDialogModel", "UserRegistered", new User(userTag, userPassword));
        }
    }
}
