using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
