using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            BlogPosts = _context.BlogPosts.ToList();
        }
    }
}
