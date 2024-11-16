using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class ListModel(AppDbContext context) : PageModel
    {
        public List<BlogPost>? BlogPosts { get; set; }

        public void OnGet()
        {
            BlogPosts = [.. context.BlogPosts];
        }
    }
}
