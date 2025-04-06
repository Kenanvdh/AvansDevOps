using DevOps.Persons;
using DevOps.Sprint.Templates;
using DevOps.Sprints;
using Moq;
using System;
using System.IO;
using Xunit;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class FailedSprintTemplateTests
    {
        // Create a subclass within the test class to expose the protected Execute method
        private class TestFailedSprintTemplate : FailedSprintTemplate
        {
            public TestFailedSprintTemplate(Sprint sprint) : base(sprint) { }

            public void CallExecute(User user)
            {
                // Public method to expose protected Execute
                Execute(user);
            }
        }

        [Fact]
        public void Execute_WritesFailureMessageToConsole()
        {
            // Arrange
            var sprint = new Sprint { Name = "Sprint 42" };
            var failedSprintTemplate = new TestFailedSprintTemplate(sprint);  
            var user = new ScrumMaster(); 

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); 

            // Act
            failedSprintTemplate.CallExecute(user);

            // Assert
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Sprint 'Sprint 42' has failed. No further action will be taken.", output);
        }
    }
}
