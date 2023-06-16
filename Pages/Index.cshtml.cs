using chat.Models;
using chat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace chat.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string userTag { get; set; }

    [BindProperty]
    public string userPassword { get; set; }
    
    public string LoginMessage { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(string message)
    {
        LoginMessage = message;
    }

    public IActionResult? OnPost()
    {
        ChatDbContext context = new ChatDbContext();
        User? loginnedUser = LoginService.CheckLoginPassword(userTag, userPassword);
        if(loginnedUser is null)
        {
            LoginMessage = "Login or Password is incorrect";
			return Page();
        }
        else
        {
            return RedirectToPage("ChooseDialogModel", "UserLoginned", loginnedUser);
        }
    }

    public IActionResult OnPostRegister()
    {
        return RedirectToPage("RegisterPage");
    }
}
