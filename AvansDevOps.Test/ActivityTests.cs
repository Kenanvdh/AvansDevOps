using DevOps;
using DevOps.Persons;
using Moq;

namespace AvansDevOps.Test
{
    public class ActivityTests
    {
        private MockRepository mockRepository;

        public ActivityTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Activity CreateActivity()
        {
            return new Activity();
        }

        [Fact]
        public void CreateActivity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var activity = this.CreateActivity();
            string name = "Activity 1";
            string description = "Description";
            User assignee = new ScrumMaster();

            // Act
            activity.CreateActivity(name, description, assignee);

            // Assert
            Assert.Equal(name, activity.Name);
            Assert.Equal(description, activity.Description);
            Assert.Equal(assignee, activity.Assignee);
            Assert.False(activity.Completed);
        }

        [Fact]
        public void MarkCompleted_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var activity = this.CreateActivity();

            // Act
            var result = activity.MarkCompleted();

            // Assert
            Assert.Equal(true, result);
        }
    }
}
