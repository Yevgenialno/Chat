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
        public User? userAddressee;

        [BindProperty]
        public string NewMessageContent { get; set;}
        public void OnGet()
        {
            //messages = messageService.GetDialog(userLoginned, userAddressee);
        }

        public IActionResult? OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            messageService.Add(NewMessageContent, (string)TempData["UserTag"], (string)TempData["UserPassword"], (string)TempData["AddresseeTag"]);
            return RedirectToPage("dialog", "DialogChosen", routeValues: new { userTag = (string)TempData["UserTag"], userPassword = (string)TempData["UserPassword"], addresseeTag = (string)TempData["AddresseeTag"]});
        }

        public IActionResult? OnGetDialogChosen(string userTag, string userPassword, string addresseeTag)
        {
            userLoginned = LoginService.CheckLoginPassword(userTag, userPassword);
			if(userLoginned is not null)
            {
				//userLoginned = user1;
				//userAddressee = user2;
				TempData["UserTag"] = userTag;
				TempData["UserPassword"] = userPassword;
                TempData["AddresseeTag"] = addresseeTag;
				messages = messageService.GetDialog(userTag, addresseeTag);
                return null;
            }
            else
                return RedirectToPage("Index");
        }

        public IActionResult OnPostBack()
        {
			return RedirectToPage("ChooseDialogModel", "UserLoginned", new User((string)TempData["UserTag"], (string)TempData["UserPassword"]));
		}
    }
}
