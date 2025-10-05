namespace BookStoreAppAPI.Model.BookDTO
{
    public class BookReadDTO : BaseDTO
    {
        public required string Title { get; set; }

        public string Image { get; set; } = string.Empty;

        public double? Price { get; set; }

        public int? AuthorId { get; set; }

        public string AuthorName { get; set; } = string.Empty;
    }
}
