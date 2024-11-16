using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class DeleteModel(AppDbContext context) : PageModel
    {
        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public IActionResult OnGet(Guid id)
        {
            BlogPost = context.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return RedirectToPage("List"); // Redirect if not found
            }
            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            BlogPost = context.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return RedirectToPage("List"); // Redirect if not found
            }

            context.BlogPosts.Remove(BlogPost);
            context.SaveChanges();
            return RedirectToPage("List");
        }
    }
}
