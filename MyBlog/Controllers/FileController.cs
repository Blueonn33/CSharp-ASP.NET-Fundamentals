using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload(IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file is { Length: > 0 })
                {
                    string unsafeFileName = Path.GetFileName(file.FileName);

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", Path.GetRandomFileName());

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    ViewBag.Message = "File uploaded successfully";
                }
                else
                {
                    ViewBag.Message = "Please select a file to upload";
                }
            }

            return View(nameof(Index));
        }
    }
}
