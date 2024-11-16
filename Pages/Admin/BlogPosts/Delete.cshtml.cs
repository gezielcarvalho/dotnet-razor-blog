using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public IActionResult OnGet(Guid id)
        {
            BlogPost = _context.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return RedirectToPage("List"); // Redirect if not found
            }
            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            BlogPost = _context.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return RedirectToPage("List"); // Redirect if not found
            }

            _context.BlogPosts.Remove(BlogPost);
            _context.SaveChanges();
            return RedirectToPage("List");
        }
    }
}
