using DevOps;
using DevOps.BacklogItems;
using DevOps.Factory;
using DevOps.Persons;
using DevOps.Sprints;
using Moq;
using Report;
using System.Xml.Linq;

namespace AvansDevOps.Test.Sprints
{
    public class SprintTests
    {
        private MockRepository mockRepository;
        private Mock<User> mockUser;

        public SprintTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockUser = this.mockRepository.Create<User>();
        }

        private Sprint CreateSprint()
        {
            return new Sprint();
        }

        private BacklogItem CreateBacklogItem()
        {
            return new BacklogItem
            {
                Title = "Test Item",
                State = BacklogItemState.ToDo,
                Assignee = mockUser.Object,
                Activities = new List<Activity>()
            };
        }

        [Fact]
        public void ChangeSprintInfo_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            sprint.Name = "Test Sprint";
            sprint.StartDate = new DateOnly(2025, 4, 1);
            sprint.EndDate = new DateOnly(2025, 4, 8);

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            sprint.ChangeSprintInfo(sprint.Name, sprint.StartDate, sprint.EndDate);

            // Assert
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Sprint Test Sprint info changed.", output);
        }


        [Fact]
        public void StartSprint_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string name = "Sprint 1";

            // Act
            sprint.StartSprint(name);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetProject_ShouldReturnAssignedProject()
        {
            // Arrange
            var expectedProject = new Project
            {
                Name = "Test Project",
                Sprints = new List<Sprint>()
            };
            var sprint = new Sprint
            {
                Name = "Sprint 1",
                StartDate = new DateOnly(2025, 4, 1),
                EndDate = new DateOnly(2025, 4, 8),
                Project = expectedProject,
                SprintMaster = new ScrumMaster()
            };

            // Act
            var actualProject = sprint.GetProject();

            // Assert
            Assert.NotNull(actualProject);
            Assert.Equal(expectedProject.Name, actualProject.Name);
        }


        [Fact]
        public void UpdateSprintState_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            sprint.Name = "Sprint 1";
            string name = "Sprint 1";
            SprintState state = SprintState.InProgress;

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            sprint.UpdateSprintState(name, state);

            // Assert: Check the console output for the expected message
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Sprint Sprint 1 state changed to InProgress", output);
        }

        [Fact]
        public void AddBacklogItem_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            sprint.Name = "Sprint 1";
            sprint.BacklogItems = new List<BacklogItem>();
            string sprintName = "Sprint 1";
            BacklogItem item = this.CreateBacklogItem();
            int itemCount = sprint.BacklogItems.Count;

            // Act
            sprint.AddBacklogItem(sprintName, item);

            // Assert
            Assert.Equal(itemCount + 1, sprint.BacklogItems.Count);
            Assert.Contains(item, sprint.BacklogItems);
        }

        [Fact]
        public void UploadReviewSummary_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            sprint.Name = "Sprint 1";
            string filePath = "filepath";

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            sprint.UploadReviewSummary(filePath);

            // Assert
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Review document 'filepath' geüpload voor sprint 'Sprint 1'.", output);
        }

        [Fact]
        public void IsScrumMaster_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            User user = new ScrumMaster();

            // Act
            var result = sprint.IsScrumMaster(user);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetItems_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            sprint.Name = "Sprint 1";
            sprint.BacklogItems = new List<BacklogItem>();
            var item1 = this.CreateBacklogItem();

            sprint.AddBacklogItem(sprint.Name, item1);

            // Act
            var result = sprint.GetItems();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Contains(item1, result);
        }
    }
}
