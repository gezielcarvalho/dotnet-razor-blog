using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class ListModel(AppDbContext context) : PageModel
    {
        public List<BlogPost>? BlogPosts { get; set; }

        public async Task OnGet()
        {
            BlogPosts = await context.BlogPosts.ToListAsync();
        }
    }
}
