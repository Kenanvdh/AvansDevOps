using DevOps;
using DevOps.Factory;
using DevOps.Persons;
using DevOps.Sprints;
using Moq;
using System.Diagnostics;

namespace AvansDevOps.Test
{
    public class ProjectTests
    {
        private MockRepository mockRepository;
        private readonly Mock<ProjectFactory> mockProjectFactory;
        private readonly Mock<SprintFactory> mockSprintFactory;
        private readonly Mock<User> mockUser;
        private readonly Project project;

        public ProjectTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockProjectFactory = new Mock<ProjectFactory>();
            this.mockSprintFactory = new Mock<SprintFactory>();
            this.mockUser = new Mock<User>();
            this.project = new Project(mockProjectFactory.Object, mockSprintFactory.Object);
        }

        private Project CreateProject()
        {
            return new Project(mockProjectFactory.Object, mockSprintFactory.Object);
        }

        [Fact]
        public void CreateProject_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockFactory = new Mock<ProjectFactory>();

            var project = new Project
            {
                Name = "Dummy Project",   // Dummy initial values
                StartDate = new DateOnly(2025, 4, 1),
                EndDate = new DateOnly(2025, 4, 8),
                ProductOwner = new ProductOwner()
            };

            mockFactory.Setup(f => f.Create(It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
                       .Returns(project);

            string name = "Dummy Project";
            DateOnly startDate = new DateOnly(2025, 4, 1);
            DateOnly endDate = new DateOnly(2025, 4, 8);
            User productOwner = new ProductOwner();

            var sprintFactory = new SprintFactory();
            var projectToCreate = new Project(mockFactory.Object, sprintFactory);

            // Act
            projectToCreate.CreateProject(name, startDate, endDate, productOwner);

            // Assert
            Assert.Equal(name, project.Name);
            Assert.Equal(startDate, project.StartDate);
            Assert.Equal(endDate, project.EndDate);
            Assert.Equal(productOwner, project.ProductOwner);
        }

        [Fact]
        public void AddSprint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string projectName = "Project";
            string sprintName = "Sprint";
            DateOnly startDate = new DateOnly(2025, 4, 1);
            DateOnly endDate = new DateOnly(2025, 4, 8);
            User sprintMaster = new ScrumMaster();
            var project = CreateProject();
            project.Name = projectName; // Ensure project name matches
            project.Sprints = new List<Sprint>();

            var mockSprint = new Mock<Sprint>();
            mockSprintFactory.Setup(f => f.Create(sprintName, startDate, endDate)).Returns(mockSprint.Object);

            // Act
            project.AddSprint(projectName, sprintName, startDate, endDate, sprintMaster);

            // Assert
            Assert.Contains(mockSprint.Object, project.Sprints);
        }

        [Fact]
        public void AddSprint_ProjectNameDoesNotMatch_PrintsErrorMessage()
        {
            // Arrange
            string projectName = "Project";
            string sprintName = "Sprint";
            DateOnly startDate = new DateOnly(2025, 4, 1);
            DateOnly endDate = new DateOnly(2025, 4, 8);
            User sprintMaster = new ScrumMaster();
            var project = CreateProject();
            project.Sprints = new List<Sprint>();

            var mockSprint = new Mock<Sprint>();
            mockSprintFactory.Setup(f => f.Create(sprintName, startDate, endDate)).Returns(mockSprint.Object);

            // Capture console output
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            project.AddSprint(projectName, sprintName, startDate, endDate, sprintMaster);

            // Assert: Check if error message was printed
            var output = consoleOutput.ToString().Trim();
            Assert.Contains($"Project {projectName} not found.", output);
        }

        [Fact]
        public void AddBacklog_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectName = "ExistingProject";
            var backlog = new Backlog();
            var project = CreateProject();
            project.Backlog = backlog;

            // Act
            project.AddBacklog(projectName, backlog);

            // Assert
            Assert.Equal(backlog, project.Backlog);
        }

        [Fact]
        public void AddBacklog_ProjectNameDoesNotMatch_PrintsErrorMessage()
        {
            // Arrange
            var projectName = "NonExistentProject";
            var backlog = new Backlog();
            var project = CreateProject(); // Create a project with a different name

            // Capture the console output
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            project.AddBacklog(projectName, backlog);

            // Assert: Check if the error message was printed
            var output = consoleOutput.ToString().Trim();
            Assert.Contains($"Project {projectName} not found.", output);
        }

        [Fact]
        public void AddBacklog_AssigningBacklogToProject_WhenNameMatches_DoesNotPrintError()
        {
            // Arrange
            var projectName = "ExistingProject";
            var backlog = new Backlog();
            var project = CreateProject();

            // Capture the console output
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            project.AddBacklog(projectName, backlog);

            // Assert: Ensure that no error message is printed
            var output = consoleOutput.ToString().Trim();
            Assert.Contains($"Project {projectName} not found.", output);
        }
    }
}
