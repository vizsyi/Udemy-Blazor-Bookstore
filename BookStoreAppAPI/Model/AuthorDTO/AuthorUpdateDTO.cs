using System.ComponentModel.DataAnnotations;

namespace BookStoreAppAPI.Model.AuthorDTO
{
    public class AuthorUpdateDTO : BaseDTO
    {
        [Required]
        [StringLength(60)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public required string LastName { get; set; }

        [StringLength(60)]
        public string? Bio { get; set; }
    }
}
