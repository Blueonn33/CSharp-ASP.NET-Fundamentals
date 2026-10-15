using System.ComponentModel.DataAnnotations;
using System.Security;

namespace MyBlog.Services.Models
{
    public class BlogServiceModel
    {
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title
        {
            get; set;
        } = null!;

        [StringLength(500)]
        public string? Description
        {
            get; set;
        }
    }
}
