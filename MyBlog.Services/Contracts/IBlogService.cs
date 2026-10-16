using MyBlog.Services.Models;

namespace MyBlog.Services.Contracts
{
    public interface IBlogService
    {
        Task CreateBlogAsync(BlogServiceModel model);

        Task<IEnumerable<BlogServiceModel>> GetAllBlogsAsync();
    }
}
