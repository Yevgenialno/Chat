using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using chat.Models;
using chat.Services;

namespace chat.Pages
{
    public class DialogModel : PageModel
    {
        public List<Message> messages = new();
        public User? userLoginned;
        
        [BindProperty]
        public Message NewMessage{get; set;} = new();
        public void OnGet()
        {
            messages = messageService.GetAll();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            NewMessage.SendTime = DateTime.Now;
            messageService.Add(NewMessage);
            return RedirectToAction("Get");
        }

        public IActionResult? OnGetUserLoginned(User user)
        {
            if (LoginService.CheckLoginPassword(user.Tag, user.Password) is not null)
            {
                userLoginned = user;
                return null;
            }
            else
                return RedirectToPage("Index");
        }
    }
}
