using MyBlog.Data.Common;
using MyBlog.Data.Models;
using MyBlog.Services.Contracts;
using MyBlog.Services.Models;

namespace MyBlog.Services.Services
{
    public class BlogService(IRepository repository) : IBlogService
    {
        public void CreateBlog(BlogServiceModel model)
        {
            var entity = new Blog()
            {
                Title = model.Title,
                Description = model.Description
            };

            repository.Add(entity);
            repository.SaveChanges();
        }

        public IEnumerable<BlogServiceModel> GetAllBlogs()
        {
            return repository.All<Blog>()
                .Select(b => new BlogServiceModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description
                });

        }
    }
}
