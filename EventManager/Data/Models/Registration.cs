using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EventManager.Common.EntityValidation.Registration;

namespace EventManager.Data.Models
{
    public class Registration
    {
        [Key]
        public Guid Id
        {
            get; set;
        }

        [ForeignKey(nameof(Event))]
        public int EventId
        {
            get; set;
        }

        public virtual Event Event
        {
            get;
            set;
        } = null!;

        [Required]
        [StringLength(ParticipantNameMaxLength, MinimumLength = ParticipantNameMinLength)]
        public string ParticipantName
        {
            get;
            set;
        } = null!;

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;
    }
}

