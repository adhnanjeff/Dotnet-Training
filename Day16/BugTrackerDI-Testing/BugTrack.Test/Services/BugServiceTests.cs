using BugTrack.Application.Services;
using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;
using BugTrack.Core.Interfaces;
using Moq;

namespace BugTrack.Test.Services {
    public class BugServiceTests {
        private readonly Mock<IBugRepository> _bugMock;
        private readonly BugService _bugService;

        public BugServiceTests() {
            _bugMock = new Mock<IBugRepository>();
            _bugService = new BugService(_bugMock.Object);
        }
        [Fact]
        public void GetAll_ShouldReturnListOfBugResponseDTOs() {
            // Arrange
            var bugs = new List<Bug> {
                new Bug { Id = 1, Title = "Bug 1", Description = "Description 1", Status = "Open", ProjectId = 1, CreatedAt = DateTime.Now, ProjectName =
                new Project{
                    Name = "Project 1",
                    Id = 1
                }},
                new Bug { Title = "Bug 2", Description = "Description 2", Status = "Closed", ProjectId = 1, CreatedAt = DateTime.Now, ProjectName =
                new Project{
                    Name = "Project 1",
                    Id = 1
                }}
            };
            _bugMock.Setup(repo => repo.GetAll()).Returns(bugs);

            // Act
            var result = _bugService.GetAllBugs().ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Bug 1", result[0].Title);
            Assert.Equal("Closed", result[1].Status);

        }

        [Fact]
        public void GetBugById_ShouldReturnBugResponseDTO_WhenBugExists()
        {
            // Arrange
            var bug = new Bug
            {
                Id = 1,
                Title = "Bug 1",
                Description = "Description 1",
                Status = "Open",
                ProjectId = 1,
                CreatedAt = DateTime.Now,
                ProjectName =
                new Project
                {
                    Name = "Project 1",
                    Id = 1
                }
            };
            _bugMock.Setup(repo => repo.GetById(1)).Returns(bug);

            // Act
            var result = _bugService.GetBugById(1);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Bug 1", result.Title);
            Assert.Equal("Description 1", result.Description);
            Assert.Equal("Open", result.Status);
        }

        [Fact]
        public void CreateBug_ShouldAddBug_WhenValidRequest()
        {
            // Arrange
            var bugRequest = new BugRequestDTO
            {
                Title = "New Bug",
                Description = "New Bug Description",
                ProjectId = 1,
                Status = "Open"
            };
            // Act
            _bugService.AddBug(bugRequest);
            // Assert
            _bugMock.Verify(repo => repo.Add(It.IsAny<Bug>()), Times.Once);
        }

        [Fact]
        public void UpdateBug_ShouldUpdateBug_WhenValidRequest()
        {
            // Arrange
            var bugRequest = new BugRequestDTO
            {
                Title = "Updated Bug",
                Description = "Updated Description",
                ProjectId = 1,
                Status = "Closed"
            };
            var existingBug = new Bug
            {
                Id = 1,
                Title = "Old Bug",
                Description = "Old Description",
                Status = "Open",
                ProjectId = 1,
                CreatedAt = DateTime.Now
            };
            _bugMock.Setup(repo => repo.GetById(1)).Returns(existingBug);
            // Act
            _bugService.UpdateBug(1, bugRequest);
            // Assert
            _bugMock.Verify(repo => repo.Update(It.IsAny<Bug>()), Times.Once);
        }
    }
}
