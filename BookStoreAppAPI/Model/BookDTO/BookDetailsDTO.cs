namespace BookStoreAppAPI.Model.BookDTO
{
    public class BookDetailsDTO : BaseDTO
    {
        public required string Title { get; set; }

        public int? Year { get; set; }

        public required string Isbn { get; set; }

        public string Summary { get; set; } = null!;

        public required string Image { get; set; }

        public double? Price { get; set; }

        public int? AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
