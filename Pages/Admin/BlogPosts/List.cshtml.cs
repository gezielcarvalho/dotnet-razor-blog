using cms_dotnet_razor.Data;
using cms_dotnet_razor.Models.Domain;
using cms_dotnet_razor.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cms_dotnet_razor.Pages.Admin.BlogPosts
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
