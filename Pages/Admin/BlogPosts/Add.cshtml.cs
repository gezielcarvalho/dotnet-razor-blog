using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using dotnet_razor_blog.Models.ViewModels;
using dotnet_razor_blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class AddModel(IBlogPostRepository repository) : PageModel
    {
        [BindProperty]
        public AddBlogPost? AddBlogPostRequest { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (AddBlogPostRequest == null)
            {
                return Page();
            }

            var blogPost = new BlogPost
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
            };
            await repository.AddAsync(blogPost);
            return RedirectToPage("List");
        }
    }
}
