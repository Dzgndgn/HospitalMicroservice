using Doccure.IdentityService.Dtos;

namespace Doccure.IdentityService.Services
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(RegisterDto dto);
        public Task<string?> LoginAsync(LoginDto dto);
    }
}
