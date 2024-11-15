using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public EditModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(Guid Id)
        {
            BlogPost = _context.BlogPosts.Find(Id);
        }

        public IActionResult OnPost()
        {
            if (BlogPost == null || !ModelState.IsValid)
            {
                return Page();
            }
            _context.BlogPosts.Update(BlogPost);
            _context.SaveChanges();
            return RedirectToPage("List");
        }
    }
}
