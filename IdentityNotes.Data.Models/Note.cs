using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityNotes.Data.Models
{
    public class Note
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public DateTime CreatedOn
        {
            get; set;
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User
        {
            get; set;
        } = null!;
    }
}
