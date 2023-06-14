using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using chat.Models;
using chat.Services;

namespace chat.Pages
{
    public class dialogModel : PageModel
    {
        public List<Message> messages = new();
        
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
    }
}
