using DevOps.Persons;
using DevOps.Sprint.Templates;
using DevOps.Sprints;
using Moq;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class ReleaseSprintTemplateTests : ReleaseSprintTemplate
    {
        private MockRepository mockRepository;
        public ReleaseSprintTemplateTests(Sprint sprint) : base(new Sprint())
        {
            this.mockRepository = mockRepository;
        }

        [Fact]
        public void Execute_WritesFailureMessageToConsole()
        {
            // Arrange
            var sprint = new Sprint { Name = "Sprint 3" };
            var releaseSprintTemplate = new ReleaseSprintTemplate(sprint);
            var user = new ScrumMaster();

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            base.Execute(user);

            // Assert
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Starting release process for sprint 'Sprint 3'...", output);
        }

    }
}
