using MyBlog.Services.Contracts;
using MyBlog.Services.Models;

namespace MyBlog.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly List<BlogServiceModel> _blogs = new();

        public void CreateBlog(BlogServiceModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogServiceModel> GetAllBlogs()
        {
            throw new NotImplementedException();
        }
    }
}
