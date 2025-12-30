using ShopBackend.DTOs.User;
using ShopBackend.Models;

namespace ShopBackend.Services {
    public interface IAuthService {

        Task<User?> RegisterAsync(UserCreateDto request);
        Task<TokenResponseDto?> LoginAsync(UserLoginDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);

    }
}
