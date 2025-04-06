using DevOps;
using DevOps.Persons;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test
{
    public class ProjectTests
    {
        private MockRepository mockRepository;



        public ProjectTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Project CreateProject()
        {
            return new Project();
        }

        [Fact]
        public void CreateProject_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var project = this.CreateProject();
            string name = null;
            DateOnly startDate = default(global::System.DateOnly);
            DateOnly endDate = default(global::System.DateOnly);
            User productOwner = null;

            // Act
            project.CreateProject(
                name,
                startDate,
                endDate,
                productOwner);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void AddSprint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var project = this.CreateProject();
            string projectName = null;
            string sprintName = null;
            DateOnly startDate = default(global::System.DateOnly);
            DateOnly endDate = default(global::System.DateOnly);
            User sprintMaster = null;

            // Act
            project.AddSprint(
                projectName,
                sprintName,
                startDate,
                endDate,
                sprintMaster);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void AddBacklog_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var project = this.CreateProject();
            string projectName = null;
            Backlog backlog = null;

            // Act
            project.AddBacklog(
                projectName,
                backlog);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
