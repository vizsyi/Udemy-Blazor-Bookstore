namespace BookStoreAppAPI.Model.Author
{
    public class AuthorReadDTO : BaseDTO
    {

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Bio { get; set; }
    }
}
