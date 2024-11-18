using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using dotnet_razor_blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class DeleteModel(IBlogPostRepository repository) : PageModel
    {
        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public async Task<IActionResult> OnGet(Guid id)
        {
            BlogPost = await repository.GetByIdAsync(id);
            if (BlogPost == null)
            {
                return RedirectToPage("List"); // Redirect if not found
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            BlogPost = await repository.GetByIdAsync(id);
            if (BlogPost == null)
            {
                return RedirectToPage("List"); // Redirect if not found
            }
            await repository.DeleteAsync(id);
            return RedirectToPage("List");
        }
    }
}
