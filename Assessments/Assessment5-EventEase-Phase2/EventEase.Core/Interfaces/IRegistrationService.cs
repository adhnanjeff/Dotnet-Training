using EventEase.Core.DTOs;

namespace EventEase.Core.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegisterationResponseDTO> AddRegistrationAsync(RegistrationRequestDTO registration);
        Task<List<RegisterationResponseDTO>> GetAllRegistrationsAsync();
        Task<RegisterationResponseDTO?> GetRegistrationByIdAsync(int id);
        Task DeleteRegistration(int id);
    }
}
