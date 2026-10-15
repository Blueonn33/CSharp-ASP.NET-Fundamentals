using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Data.Models
{
    [Comment("Represents a blog entity in the application")]
    public class Blog
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(100)]
        public required string Title
        {
            get; set;
        }

        [MaxLength(500)]
        public string? Description
        {
            get; set;
        }
    }
}
