using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Common;
using MyBlog.Data.Models;
using MyBlog.Services.Contracts;
using MyBlog.Services.Models;

namespace MyBlog.Services.Services
{
    public class BlogService(IRepository repository) : IBlogService
    {
        public async Task CreateBlogAsync(BlogServiceModel model)
        {
            var entity = new Blog()
            {
                Title = model.Title,
                Description = model.Description
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogServiceModel>> GetAllBlogsAsync()
        {
            return await repository.All<Blog>()
                .Select(b => new BlogServiceModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description
                })
                .ToListAsync();
        }
    }
}
