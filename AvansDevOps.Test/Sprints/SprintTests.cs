using DevOps;
using DevOps.BacklogItems;
using DevOps.Persons;
using DevOps.Sprints;
using Moq;

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
            string name = null;
            DateOnly startDate = default;
            DateOnly endDate = default;

            // Act
            sprint.ChangeSprintInfo(name, startDate, endDate);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetProject_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();

            // Act
            var result = sprint.GetProject();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
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
        public void UpdateSprintState_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string name = "Sprint 1";
            SprintState state = SprintState.InProgress;

            // Act
            sprint.UpdateSprintState(name, state);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void AddBacklogItem_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string sprintName = "Sprint 1";
            BacklogItem item = this.CreateBacklogItem();

            // Act
            sprint.AddBacklogItem(sprintName, item);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UploadReviewSummary_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string filePath = null;

            // Act
            sprint.UploadReviewSummary(filePath);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
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

            // Act
            var result = sprint.GetItems();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
