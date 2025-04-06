using DevOps;
using DevOps.BacklogItems;
using DevOps.Persons;
using DevOps.Sprint.Templates;
using DevOps.Sprints;
using Moq;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class ReviewSprintTemplateTests : ReviewSprintTemplate
    {
        private MockRepository mockRepository;
        private Mock<User> mockUser;
        private Mock<Activity> mockActivity;

        public ReviewSprintTemplateTests(Sprint sprint) : base(new Sprint())
        {
            this.mockRepository = mockRepository;
            this.mockUser = this.mockRepository.Create<User>();
            this.mockActivity = this.mockRepository.Create<Activity>();
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
        public void Execute_WritesFailureMessageToConsole()
        {
            // Arrange
            var sprint = new Sprint { Name = "Sprint 4" };
            var backlogItem1 = this.CreateBacklogItem();

            sprint.AddBacklogItem(sprint.Name, backlogItem1);

            var template = new ReviewSprintTemplateTests(sprint);
            var user = new ScrumMaster();

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            base.Execute(user);

            // Assert: Check if all items are Done
            Assert.Equal(BacklogItemState.Done, backlogItem1.State);

            // Assert: Check console output
            var output = consoleOutput.ToString().Trim();
            var expectedOutput =
                $"Review Sprint: Planning review for sprint 'Sprint 21'...{Environment.NewLine}" +
                $"All backlog items in sprint 'Sprint 21' are marked as Done.";

            Assert.Equal(expectedOutput, output);
        }

    }
}
