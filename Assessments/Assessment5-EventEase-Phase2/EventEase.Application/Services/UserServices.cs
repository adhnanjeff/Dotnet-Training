using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using EventEase.Core.Exceptions;

namespace EventEase.Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDTO> AddUserAsync(UserRequestDTO userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Email))
                throw new ValidationException("User email cannot be empty.");

            var allUsers = await _userRepository.GetAllAsync();

            // Prevent duplicate email
            if (allUsers.Any(u => u.Email == userDto.Email))
                throw new ConflictException($"A user with email {userDto.Email} already exists.");

            int nextId = allUsers.Any()
                ? allUsers.Max(u => u.Id) + 1
                : 1;

            var user = new User
            {
                Id = nextId,
                Name = userDto.Name,
                Email = userDto.Email
            };

            await _userRepository.AddAsync(user);

            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Events = new List<string>()
            };
        }

        public async Task UpdateUserAsync(int id, UserRequestDTO userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null)
                throw new NotFoundException($"User with ID {id} not found.");

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;

            await _userRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new NotFoundException($"User with ID {id} not found.");

            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Events = u.EventsParticipating.Select(e => e.Title).ToList()
            }).ToList();
        }

        public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new NotFoundException($"User with ID {id} not found.");

            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Events = user.EventsParticipating.Select(e => e.Title).ToList()
            };
        }
    }
}
