using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookVerse.DataModels
{
    [PrimaryKey(nameof(UserId), nameof(BookId))]
    public class UserBook
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        public int BookId
        {
            get; set;
        }

        [ForeignKey(nameof(BookId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Book Book { get; set; } = null!;
    }
}
