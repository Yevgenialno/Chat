using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using chat.Models;
using chat.Services;

namespace chat.Pages
{
    public class dialogModel : PageModel
    {
        public List<message> messages = new();
        
        [BindProperty]
        public message NewMessage{get; set;} = new();
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
            messageService.Add(NewMessage);
            return RedirectToAction("Get");
        }
    }
}
