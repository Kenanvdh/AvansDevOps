using DevOps.BacklogItems;
using DevOps.Persons;
using DevOps.Sprints;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test.Sprints
{
    public class SprintTests
    {
        private MockRepository mockRepository;



        public SprintTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Sprint CreateSprint()
        {
            return new Sprint();
        }

        [Fact]
        public void ChangeSprintInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string name = null;
            DateOnly startDate = default(global::System.DateOnly);
            DateOnly endDate = default(global::System.DateOnly);

            // Act
            sprint.ChangeSprintInfo(
                name,
                startDate,
                endDate);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetProject_StateUnderTest_ExpectedBehavior()
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
        public void StartSprint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string name = null;

            // Act
            sprint.StartSprint(
                name);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateSprintState_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string name = null;
            SprintState state = default(global::DevOps.Sprints.SprintState);

            // Act
            sprint.UpdateSprintState(
                name,
                state);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void AddBacklogItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string sprintName = null;
            BacklogItem item = null;

            // Act
            sprint.AddBacklogItem(
                sprintName,
                item);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UploadReviewSummary_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            string filePath = null;

            // Act
            sprint.UploadReviewSummary(
                filePath);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void IsScrumMaster_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprint = this.CreateSprint();
            User user = null;

            // Act
            var result = sprint.IsScrumMaster(
                user);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetItems_StateUnderTest_ExpectedBehavior()
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
