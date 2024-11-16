using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class EditModel(AppDbContext context) : PageModel
    {
        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public void OnGet(Guid Id)
        {
            BlogPost = context.BlogPosts.Find(Id);
        }

        public IActionResult OnPost()
        {
            if (BlogPost == null || !ModelState.IsValid)
            {
                return Page();
            }
            context.BlogPosts.Update(BlogPost);
            context.SaveChanges();
            return RedirectToPage("List");
        }
    }
}
