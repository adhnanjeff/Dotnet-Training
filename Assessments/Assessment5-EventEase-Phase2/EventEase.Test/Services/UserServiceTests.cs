using EventEase.Application.Services;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using Moq;
using Xunit;

namespace EventEase.Test.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly UserServices _userService;

        public UserServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _userService = new UserServices(_userRepoMock.Object);
        }

        [Fact]
        public async Task AddUserAsync_ShouldAssignNextId_AndReturnUserResponse()
        {
            // Arrange
            var existingUsers = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@test.com" }
            };
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(existingUsers);
            _userRepoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var request = new UserRequestDTO { Name = "Alice", Email = "alice@test.com" };

            // Act
            var result = await _userService.AddUserAsync(request);

            // Assert
            Assert.Equal(2, result.Id); // Next ID
            Assert.Equal("Alice", result.Name);
            Assert.Equal("alice@test.com", result.Email);
            _userRepoMock.Verify(r => r.AddAsync(It.Is<User>(u => u.Id == 2)), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldUpdateUser_WhenExists()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@test.com" }
            };
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);
            _userRepoMock.Setup(r => r.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var request = new UserRequestDTO { Name = "Updated", Email = "updated@test.com" };

            // Act
            await _userService.UpdateUserAsync(1, request);

            // Assert
            _userRepoMock.Verify(r => r.UpdateAsync(It.Is<User>(u =>
                u.Id == 1 &&
                u.Name == "Updated" &&
                u.Email == "updated@test.com"
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<User>());

            var request = new UserRequestDTO { Name = "Updated", Email = "updated@test.com" };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _userService.UpdateUserAsync(99, request));
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldCallRepository()
        {
            // Arrange
            _userRepoMock.Setup(r => r.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            await _userService.DeleteUserAsync(1);

            // Assert
            _userRepoMock.Verify(r => r.DeleteAsync(1), Times.Once);
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
                    Name = "John",
                    Email = "john@test.com",
                    EventsParticipating = new List<Event>
                    {
                        new Event {
                            Id = 1,
                            Title = "Tech Conference" ,
                            Description = "An annual tech event",
                            EventDate = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
                            Location = "San Francisco",
                            Participants = new List<User>()
                        }
                    }
                }
            };
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
            Assert.Contains("Tech Conference", result[0].Events);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser_WhenExists()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "John",
                Email = "john@test.com",
                EventsParticipating = new List<Event>
                {
                    new Event { 
                        Id = 1, 
                        Title = "Tech Conference" ,
                        Description = "An annual tech event",
                        EventDate = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
                        Location = "San Francisco",
                        Participants = new List<User>()
                    }
                }
            };
            _userRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Contains("Tech Conference", result.Events);
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
