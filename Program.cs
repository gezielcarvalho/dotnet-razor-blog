using cms_dotnet_razor.Data;
using cms_dotnet_razor.Models;
using cms_dotnet_razor.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cms_dotnet_razor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Bind Recaptcha settings
            builder.Services.Configure<RecaptchaSettings>(builder.Configuration.GetSection("Recaptcha"));

            builder.Services.AddScoped<IBlogPostRepository, BlogRepository>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
