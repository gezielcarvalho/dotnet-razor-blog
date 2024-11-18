using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using dotnet_razor_blog.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class ListModel(IBlogPostRepository repository) : PageModel
    {
        public IEnumerable<BlogPost>? BlogPosts { get; set; }

        public async Task OnGet()
        {
            BlogPosts = await repository.GetAllAsync();
        }
    }
}
