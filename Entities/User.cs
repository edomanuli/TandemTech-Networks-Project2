using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(60, ErrorMessage = "First name cannot be longer than 60 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(60, ErrorMessage = "Last name cannot be longer than 60 characters.")]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

    }
}
