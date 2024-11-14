using dotnet_razor_blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Add");
        }
    }
}
