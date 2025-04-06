using DevOps;
using DevOps.BacklogItems;
using DevOps.Persons;
using Moq;

namespace AvansDevOps.Test
{
    public class BacklogTests
    {
        private MockRepository mockRepository;

        public BacklogTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Backlog CreateBacklog()
        {
            return new Backlog();
        }

        [Fact]
        public void AddItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var backlog = new Backlog();
            var item = new BacklogItem
            {
                Title = "New Task",
                Activities = new List<Activity>(),
                Assignee = new Developer(),
                State = new BacklogItemState()
            };

            // Act
            backlog.AddItem(item);

            // Assert
            Assert.Single(backlog.BacklogItems);
            Assert.Contains(item, backlog.BacklogItems);
        }

        [Fact]
        public void AddItem_DuplicateItem_DoesNotAddAndPrintsWarning()
        {
            // Arrange
            var backlog = new Backlog();
            var item = new BacklogItem
            {
                Title = "Duplicate Task",
                Activities = new List<Activity>(),
                Assignee = new Developer(),
                State = new BacklogItemState()
            };
            backlog.AddItem(item);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlog.AddItem(item);

            // Assert
            Assert.Single(backlog.BacklogItems); // Should still only be one
            var output = sw.ToString().Trim();
            Assert.Equal("Item already exists in the backlog.", output);
        }

    }
}
