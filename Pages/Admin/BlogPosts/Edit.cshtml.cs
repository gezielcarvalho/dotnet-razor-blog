using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models;
using dotnet_razor_blog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace dotnet_razor_blog.Pages.Admin.BlogPosts
{
    public class EditModel(AppDbContext context, IOptions<RecaptchaSettings> recaptchaSettings) : PageModel
    {
        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public async Task OnGet(Guid Id)
        {
            BlogPost = await context.BlogPosts.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            // Extract reCAPTCHA response token from the form submission
            var recaptchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = recaptchaSettings.Value.SecretKey;

            // Send the response to Google for validation
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaResponse}", null);
            var json = await response.Content.ReadAsStringAsync();
            var captchaResult = JsonSerializer.Deserialize<RecaptchaResponse>(json);

            // Check if reCAPTCHA was successful
            if (captchaResult == null || !captchaResult.Success)
            {
                ModelState.AddModelError(string.Empty, "reCAPTCHA validation failed. Please try again.");
                return Page();
            }

            if (BlogPost == null || !ModelState.IsValid)
            {
                return Page();
            }
            context.BlogPosts.Update(BlogPost);
            await context.SaveChangesAsync();
            return RedirectToPage("List");
        }
    }
}
