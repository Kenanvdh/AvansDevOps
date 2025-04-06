using DevOps;
using DevOps.BacklogItems;
using DevOps.Persons;
using DevOps.Sprint.Templates;
using DevOps.Sprints;
using Moq;
using System;
using System.IO;
using Xunit;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class ReviewSprintTemplateTests
    {
        private MockRepository mockRepository;
        private Mock<User> mockUser;
        private Mock<Activity> mockActivity;

        public ReviewSprintTemplateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this.mockUser = this.mockRepository.Create<User>();
            this.mockActivity = this.mockRepository.Create<Activity>();
        }

        private class TestReviewSprintTemplate : ReviewSprintTemplate
        {
            public TestReviewSprintTemplate(Sprint sprint) : base(sprint) { }

            public void CallExecute(User user)
            {
                // Public method to expose protected Execute
                Execute(user);
            }
        }

        [Fact]
        public void Execute_WritesReviewMessageToConsole()
        {
            // Arrange
            var sprint = new Sprint { Name = "Sprint 4", BacklogItems = new List<BacklogItem>() };
            var backlogItem1 = new BacklogItem
            {
                Title = "Test Item",
                State = BacklogItemState.Tested, // Set initial state to Tested
                Assignee = mockUser.Object,
                Activities = new List<Activity>()
            };

            sprint.AddBacklogItem(sprint.Name, backlogItem1);

            var template = new TestReviewSprintTemplate(sprint);
            var user = new ScrumMaster();

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            template.CallExecute(user);

            // Assert: Check if all items are Done
            foreach (var item in sprint.GetItems())
            {
                Assert.Equal(BacklogItemState.Done, item.State);
            }

            // Assert: Check console output
            var output = consoleOutput.ToString().Trim();
            var expectedOutput =
                $"Review Sprint: Planning review for sprint 'Sprint 4'...{Environment.NewLine}" +
                $"State changed to Done{Environment.NewLine}" +
                $"All backlog items in sprint 'Sprint 4' are marked as Done.";

            Assert.Equal(expectedOutput, output);
        }
    }
}


