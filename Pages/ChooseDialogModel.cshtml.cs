using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using chat.Models;

namespace chat.Pages
{
    public class ChooseDialogModel : PageModel
    {
        public DbSet<User>? startedDialogs { get; set; }
        public void OnGet()
        {
        }
    }
}
