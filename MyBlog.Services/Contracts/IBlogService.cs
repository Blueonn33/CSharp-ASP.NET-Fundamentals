using MyBlog.Services.Models;

namespace MyBlog.Services.Contracts
{
    public interface IBlogService
    {
        void CreateBlog(BlogServiceModel model);

        IEnumerable<BlogServiceModel> GetAllBlogs();
    }
}
