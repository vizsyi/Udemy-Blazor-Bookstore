using System.ComponentModel.DataAnnotations;

namespace BookStoreAppAPI.Model.BookDTO
{
    public class BookCreateDTO
    {
        [Required]
        [StringLength(30)]
        public required string Title { get; set; }

        [Required]
        [Range(1000,2100)]
        public int? Year { get; set; }

        [Required]
        [StringLength(20)]
        public required string Isbn { get; set; }

        [Required]
        [StringLength(60, MinimumLength =10)]
        public required string Summary { get; set; }

        [Required]
        public required string Image { get; set; }

        [Required]
        [Range(000, int.MaxValue)]
        public decimal Price { get; set; }

        //public int? AuthorId { get; set; }
    }
}
