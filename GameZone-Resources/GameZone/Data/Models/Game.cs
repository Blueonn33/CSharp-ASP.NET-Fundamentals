using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl
        {
            get; set;
        }

        [Required]
        [StringLength(GamePublisherMaxLength, MinimumLength = GamePublisherMinLength)]
        public string PublisherName { get; set; } = null!;

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ReleasedOn
        {
            get; set;
        }

        public int GenreId
        {
            get; set;
        }

        public virtual Genre Genre { get; set; } = null!;
    }
}
