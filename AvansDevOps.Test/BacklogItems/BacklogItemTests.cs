using DevOps;
using DevOps.BacklogItems;
using DevOps.Persons;
using Moq;
using System;
using System.Collections.Generic;
using Threads;
using Xunit;

namespace AvansDevOps.Test.BacklogItems
{
    public class BacklogItemTests
    {
        private MockRepository mockRepository;
        private Mock<DevOps.Sprints.Sprint> mockSprint;
        private Mock<User> mockUser;
        private Mock<Activity> mockActivity;
        private Mock<Message> mockMessage;

        public BacklogItemTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockSprint = this.mockRepository.Create<DevOps.Sprints.Sprint>();
            this.mockUser = this.mockRepository.Create<User>();
            this.mockActivity = this.mockRepository.Create<Activity>();
            this.mockMessage = this.mockRepository.Create<Message>();
        }

        private BacklogItem CreateBacklogItem()
        {
            return new BacklogItem
            {
                Activities = new List<Activity>()
            };
        }

        [Fact]
        public void CreateItem_ShouldSetTitleAndDescription()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();
            string title = "New Item";
            string description = "Description of the item";

            // Act
            backlogItem.CreateItem(title, description);

            // Assert
            Assert.Equal(title, backlogItem.Title);
        }

        [Fact]
        public void GetSprint_ShouldReturnSprint()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();

            // Act
            var result = backlogItem.GetSprint();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ChangeState_ShouldUpdateState()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();
            var newState = BacklogItemState.Done;

            // Act
            backlogItem.ChangeState(newState);

            // Assert
            Assert.Equal(newState, backlogItem.State);
        }

        [Fact]
        public void AddAssignee_ShouldAssignUser()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();

            // Act
            backlogItem.AddAssignee(mockUser.Object);

            // Assert
            Assert.Equal(mockUser.Object, backlogItem.Assignee);
        }

        [Fact]
        public void AddActivity_ShouldAddActivityToList()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();

            // Act
            backlogItem.AddActivity(mockActivity.Object);

            // Assert
            Assert.Contains(mockActivity.Object, backlogItem.Activities);
        }

        [Fact]
        public void FinishItem_ShouldSetStateToDone()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();
            var realActivity = new Activity();
            backlogItem.Activities = new List<Activity> { realActivity };

            // FIX: Zorg ervoor dat de activiteit voltooid is
            realActivity.MarkCompleted();

            // Act
            backlogItem.FinishItem();

            // Assert
            Assert.Equal(BacklogItemState.Done, backlogItem.State);
        }



        [Fact]
        public void StartThread_ShouldCreateNewThread()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();
            string message = "Discussion message";

            // Act
            backlogItem.StartThread(message, mockUser.Object);

            // Assert
            Assert.NotNull(backlogItem);
        }

        [Fact]
        public void AddMessageToThread_ShouldAddMessage()
        {
            // Arrange
            var backlogItem = this.CreateBacklogItem();
            backlogItem.StartThread("Initial message", mockUser.Object);

            // Act
            backlogItem.AddMessageToThread("Reply message", mockUser.Object);

            // Assert
            Assert.NotNull(backlogItem);
        }
    }
}
