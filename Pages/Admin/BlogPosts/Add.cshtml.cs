using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using dotnet_razor_blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        private readonly AppDbContext _context;
        public AddModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.BlogPosts.Add(new BlogPost
            {
                Author = AddBlogPostRequest.Author,
                Content = AddBlogPostRequest.Content,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                Heading = AddBlogPostRequest.Heading,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                PageTitle = AddBlogPostRequest.PageTitle,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                Visible = AddBlogPostRequest.IsVisible
            });
            _context.SaveChanges();
            return RedirectToPage("Add");
        }
    }
}
