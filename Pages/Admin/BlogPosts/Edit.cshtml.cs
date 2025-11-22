using cms_dotnet_razor.Data;
using cms_dotnet_razor.Models;
using cms_dotnet_razor.Models.Domain;
using cms_dotnet_razor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace cms_dotnet_razor.Pages.Admin.BlogPosts
{
    public class EditModel(IOptions<RecaptchaSettings> recaptchaSettings, IBlogPostRepository repository) : PageModel
    {
        [BindProperty]
        public BlogPost? BlogPost { get; set; }

        public async Task OnGet(Guid Id)
        {
            BlogPost = await repository.GetByIdAsync(Id);
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
            await repository.UpdateAsync(BlogPost);
            return RedirectToPage("List");
        }
    }
}
