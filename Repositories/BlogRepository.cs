using dotnet_razor_blog.Data;
using dotnet_razor_blog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet_razor_blog.Repositories
{
    public class BlogRepository : IBlogPostRepository
    {
        private readonly AppDbContext context;

        public BlogRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            context.BlogPosts.Add(blogPost);
            await context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var blogPost = await context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return false;
            }
            context.BlogPosts.Remove(blogPost);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(Guid id)
        {
            return await context.BlogPosts.FindAsync(id) ?? throw new InvalidOperationException("Blog post not found");
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            context.BlogPosts.Update(blogPost);
            await context.SaveChangesAsync();
            return blogPost;
        }
    }
}
