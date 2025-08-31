using Ecommerce.Core.DTOs;
using Ecommerce.Core.DTOs.Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> CreateUser(UserRequestDTO user);
        Task<UserResponseDTO> AddUserAsync(UserRequestDTO user);
        Task UpdateUserAsync(int id, UserRequestDTO user);
        Task DeleteUserAsync(int id);
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO?> GetUserByIdAsync(int id);
    }
}
