using AutoMapper;
using Ecommerce.Application.Mapping;
using Ecommerce.Application.Services;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Moq;
using Xunit;

namespace Ecommerce.Test.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mapperConfig.CreateMapper();
            _userService = new UserService(_userRepoMock.Object, _mapper);
        }

        [Fact]
        public async Task AddUserAsync_ShouldAssignNextId_AndReturnUserResponse()
        {
            // Arrange
            var existingUsers = new List<User>
            {
                new User { Id = 1, Username = "Adhnan", Email = "adhnan@test.com" }
            };
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(existingUsers);
            _userRepoMock
                .Setup(r => r.AddAsync(It.IsAny<User>()))
                .Callback<User>(u => u.Id = 2)
                .Returns(Task.CompletedTask);

            var request = new UserRequestDTO { Username = "Subashini", Email = "subashini@test.com" };

            // Act
            var result = await _userService.AddUserAsync(request);

            // Assert
            Assert.Equal(2, result.Id);
            Assert.Equal("Subashini", result.Username);
            Assert.Equal("subashini@test.com", result.Email);
            _userRepoMock.Verify(r => r.AddAsync(It.Is<User>(u => u.Id == 2)), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldUpdateUser_WhenExists()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Username = "Ahalya", Email = "ahalya@test.com" }
            };
            _userRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(users.First());
            _userRepoMock.Setup(r => r.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var request = new UserRequestDTO { Username = "Amrith", Email = "amrith@test.com" };

            // Act
            await _userService.UpdateUserAsync(1, request);

            // Assert
            _userRepoMock.Verify(r => r.UpdateAsync(It.Is<User>(u =>
                u.Id == 1 &&
                u.Username == "Amrith" &&
                u.Email == "amrith@test.com"
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            _userRepoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((User?)null);

            var request = new UserRequestDTO { Username = "Sivadarsini", Email = "sivadarsini@test.com" };

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _userService.UpdateUserAsync(99, request));
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnMappedUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "Adhnan",
                    Email = "adhnan@test.com"
                },
                new User
                {
                    Id = 2,
                    Username = "Subashini",
                    Email = "subashini@test.com"
                }
            };
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, r => r.Username == "Adhnan");
            Assert.Contains(result, r => r.Username == "Subashini");
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser_WhenExists()
        {
            // Arrange
            var user = new User
            {
                Id = 3,
                Username = "Ahalya",
                Email = "ahalya@test.com"
            };
            _userRepoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(3);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ahalya", result.Username);
            Assert.Equal("ahalya@test.com", result.Email);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            _userRepoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetUserByIdAsync(99);

            // Assert
            Assert.Null(result);
        }
    }
}
