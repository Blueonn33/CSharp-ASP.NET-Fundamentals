using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Contracts;
using MyBlog.Services.Models;

namespace MyBlog.Controllers
{
    // Primary constructor
    public class BlogController(IBlogService blogService) : Controller
    {
        //private readonly IBlogService _blogService;
        //public BlogController(IBlogService blogService)
        //{
        //    blogService = _blogService;
        //}

        [HttpGet]
        public IActionResult Index()
        {
            var blogs = blogService.GetAllBlogs();

            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BlogServiceModel model = new BlogServiceModel();


            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BlogServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            blogService.CreateBlog(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
