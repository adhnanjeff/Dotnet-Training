using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.DTOs.Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> AddUserAsync(UserRequestDTO user)
        {
            var entity = _mapper.Map<User>(user);
            await _userRepository.AddAsync(entity);
            return _mapper.Map<UserResponseDTO>(entity);
        }

        public async Task UpdateUserAsync(int id, UserRequestDTO user)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"User with Id {id} not found.");

            _mapper.Map(user, existing); // map updated fields into existing entity
            await _userRepository.UpdateAsync(existing);
        }

        public async Task DeleteUserAsync(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"User with Id {id} not found.");

            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserResponseDTO>>(users);
        }

        public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserResponseDTO>(user);
        }
    }
}
