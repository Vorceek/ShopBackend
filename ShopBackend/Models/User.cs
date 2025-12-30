using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShopBackend.Models {
    public class User {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(30)]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(256)]
        public string PasswordHash { get; set; } = default!;

        [Required(ErrorMessage = "E-mail is required.")]
        [StringLength(256)]
        public string Email { get; set; } = default!;

        public string Role { get; set; } = "User";
        public bool IsActive { get; set; } = true;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }
}
