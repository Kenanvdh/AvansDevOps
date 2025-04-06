using DevOps.BacklogItems;
using DevOps;
using DevOps.Persons;
using DevOps.Sprints;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test.Persons
{
    public class ScrumMasterTests
    {
        private MockRepository mockRepository;

        public ScrumMasterTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private ScrumMaster CreateScrumMaster()
        {
            return new ScrumMaster();
        }

        private Sprint CreateSprint()
        {
            return new Sprint
            {
                Name = "Sprint 1",
                StartDate = new DateOnly(2023, 1, 1),
                EndDate = new DateOnly(2023, 1, 15),
                BacklogItems = new List<BacklogItem>(),
                State = SprintState.Planned,
                SprintMaster = new ScrumMaster { Name = "SprintMaster" },
                Project = new Project { Name = "Project 1" }
            };
        }

        [Fact]
        public void CloseSprint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scrumMaster = this.CreateScrumMaster();
            var sprint = this.CreateSprint();
            Console.WriteLine("CloseSprint test started");

            // Act
            ScrumMaster.CloseSprint(sprint);
            Console.WriteLine("CloseSprint method called");

            // Assert
            Assert.True(true); // Adjust the assertion as needed
            this.mockRepository.VerifyAll();
            Console.WriteLine("CloseSprint test completed");
        }

        [Fact]
        public void GeneratePdfReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scrumMaster = this.CreateScrumMaster();
            var sprint = this.CreateSprint();
            Console.WriteLine("GeneratePdfReport test started");

            // Act
            ScrumMaster.GeneratePdfReport(sprint);
            Console.WriteLine("GeneratePdfReport method called");

            // Assert
            Assert.True(true); // Adjust the assertion as needed
            this.mockRepository.VerifyAll();
            Console.WriteLine("GeneratePdfReport test completed");
        }

        [Fact]
        public void GeneratePngReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scrumMaster = this.CreateScrumMaster();
            var sprint = this.CreateSprint();
            Console.WriteLine("GeneratePngReport test started");

            // Act
            ScrumMaster.GeneratePngReport(sprint);
            Console.WriteLine("GeneratePngReport method called");

            // Assert
            Assert.True(true); // Adjust the assertion as needed
            this.mockRepository.VerifyAll();
            Console.WriteLine("GeneratePngReport test completed");
        }
    }
}
