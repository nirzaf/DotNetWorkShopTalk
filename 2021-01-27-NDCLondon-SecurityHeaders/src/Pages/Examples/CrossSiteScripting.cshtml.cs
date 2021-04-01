using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityHeadersTalk.Pages.Examples
{
    public class CrossSiteScriptingModel : PageModel
    {
        [BindProperty]
        public string Input { get; set; }
        
        public string Message { get; set; }

        public void OnGet(string message)
        {
            Message = message;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { message = Input});
        }
    }
}