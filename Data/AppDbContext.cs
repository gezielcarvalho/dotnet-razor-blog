using cms_dotnet_razor.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace cms_dotnet_razor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
