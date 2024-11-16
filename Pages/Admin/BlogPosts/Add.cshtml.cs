using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using dotnet_razor_blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class AddModel(AppDbContext context) : PageModel
    {
        [BindProperty]
        public AddBlogPost? AddBlogPostRequest { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (AddBlogPostRequest == null)
            {
                return Page();
            }
            context.BlogPosts.Add(new BlogPost
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
            context.SaveChanges();
            return RedirectToPage("List");
        }
    }
}
