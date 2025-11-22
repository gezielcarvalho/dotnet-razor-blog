using cms_dotnet_razor.Models.Domain;

namespace cms_dotnet_razor.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost> GetByIdAsync(Guid id);
        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<bool> DeleteAsync(Guid id);

    }
}
