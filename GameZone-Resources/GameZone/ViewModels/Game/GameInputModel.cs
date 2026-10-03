using GameZone.ViewModels.Genre;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants;

namespace GameZone.ViewModels.Game
{
    public class GameInputModel
    {
        // Input Model -> Data flow is from Client (UNTRUSTED) to Server App (TRUSTED)
        // We MUST perform Model Validation to transform UNTRUSTED context to TRUSTED context

        // Inputs (UNTRUSTED -> TRUSTED) Model Validation required
        [Required]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength)]
        public string Title { get; set; } = null!;

        [Url]
        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl
        {
            get; set;
        }

        [Required]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(GamePublisherMaxLength, MinimumLength = GamePublisherMinLength)]
        public string PublisherName { get; set; } = null!;

        public DateTime ReleasedOn
        {
            get; set;
        }

        // Validation in Controller -> Validate that Genre exists
        public int GenreId
        {
            get; set;
        }
        // Inputs (UNTRUSTED -> TRUSTED) Model Validation required

        // Outputs (TRUSTED -> UNTRUSTED) Model Validation is not required
        public IEnumerable<GenreDropDownViewModel> Genres
        {
            get; set;
        } = new List<GenreDropDownViewModel>();
    }
}
