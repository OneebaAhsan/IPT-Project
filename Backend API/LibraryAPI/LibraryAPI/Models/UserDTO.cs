using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Password { get; set; } = string.Empty;
    }

    public class UserDTO : LoginUserDTO
    {
        [Required]
        [StringLength (25)]
        public string UserName { get; set; } = string.Empty;

        public ICollection<string> Roles { get; set; }
    }
}
