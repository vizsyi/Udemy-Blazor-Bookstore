using System.ComponentModel.DataAnnotations;

namespace BookStoreAppAPI.Model.BookDTO
{
    public class BookUpdateDTO : BaseDTO
    {
        [Required]
        [StringLength(30)]
        public required string Title { get; set; }

        public int? Year { get; set; }

        [Required]
        [StringLength(20)]
        public required string Isbn { get; set; }

        [Required]
        [StringLength(60)]
        public required string Summary { get; set; }

        [Required]
        public required string Image { get; set; }

        public double? Price { get; set; }

        public int? AuthorId { get; set; }
    }
}
