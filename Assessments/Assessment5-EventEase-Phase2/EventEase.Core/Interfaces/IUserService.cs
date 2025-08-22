using EventEase.Core.DTOs;

namespace EventEase.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> AddUserAsync(UserRequestDTO user);
        Task UpdateUserAsync(int id, UserRequestDTO user);
        Task DeleteUserAsync(int id);
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO?> GetUserByIdAsync(int id);
    }

}
