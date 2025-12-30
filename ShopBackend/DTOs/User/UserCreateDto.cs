using System.ComponentModel.DataAnnotations;

namespace ShopBackend.DTOs.User {
    public class UserCreateDto {

        [Required]
        [StringLength(30)]
        public string Username { get; set; } = default!;

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(128)]
        public string Password { get; set; } = default!;

    }
}
