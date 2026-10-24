using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static IdentityNotes.Common.EntityValidation.Note;

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
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Column(TypeName = CreatedOnColumnType)]
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
