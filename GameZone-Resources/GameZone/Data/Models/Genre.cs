using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(GenreNameMaxLength, MinimumLength = GenreNameMinLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
