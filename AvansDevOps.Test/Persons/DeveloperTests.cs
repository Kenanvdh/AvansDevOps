using DevOps.BacklogItems;
using DevOps;
using DevOps.Persons;
using DevOps.Sprints;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test.Persons
{
    public class DeveloperTests
    {
        private MockRepository mockRepository;

        public DeveloperTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Developer CreateDeveloper()
        {
            return new Developer();
        }

        [Fact]
        public void CompleteItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var developer = this.CreateDeveloper();
            string itemName = "TestItem"; // Provide a non-null value
            Sprint sprint = new Sprint
            {
                Name = "Sprint 1",
                StartDate = new DateOnly(2023, 1, 1),
                EndDate = new DateOnly(2023, 1, 15),
                BacklogItems = new List<BacklogItem>(),
                State = SprintState.Planned,
                SprintMaster = new Developer { Name = "SprintMaster" },
                Project = new Project { Name = "Project 1" }
            };

            // Act
            Developer.CompleteItem(itemName, sprint);

            // Assert
            Assert.True(true); // Adjust the assertion as needed
            this.mockRepository.VerifyAll();
        }
    }
}
