using System.ComponentModel.DataAnnotations;
using static BookVerse.GCommon.ValidationConstants.Genre;

namespace BookVerse.DataModels
{
    public class Genre
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required, StringLength(NameMax)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
