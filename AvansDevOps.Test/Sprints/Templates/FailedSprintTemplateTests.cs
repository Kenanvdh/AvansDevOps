using DevOps.Persons;
using DevOps.Sprint.Templates;
using DevOps.Sprints;
using Moq;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class FailedSprintTemplateTests : FailedSprintTemplate
    {
        private MockRepository mockRepository;
        public FailedSprintTemplateTests(Sprint sprint) : base(new Sprint())
        {
            this.mockRepository = mockRepository;
        }

        [Fact]
        public void Execute_WritesFailureMessageToConsole()
        {
            // Arrange
            var sprint = new Sprint { Name = "Sprint 42" };
            var failedSprintTemplate = new FailedSprintTemplate(sprint);
            var user = new ScrumMaster();

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            base.Execute(user);

            // Assert
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Sprint 'Sprint 42' has failed. No further action will be taken.", output);
        }

    }
}
