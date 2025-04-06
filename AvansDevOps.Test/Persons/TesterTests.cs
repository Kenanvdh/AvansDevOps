using System;
using System.Collections.Generic;
using System.Linq;
using DevOps.Persons;
using DevOps.Sprints;
using DevOps.BacklogItems;
using Moq;
using Xunit;

namespace DevOps.Tests
{
    public class TesterTests
    {
        private User CreateMockUser()
        {
            var mockUser = new Mock<User>();
            mockUser.SetupAllProperties();
            return mockUser.Object;
        }

        [Fact]
        public void TestItem_ItemNotFound_ShouldNotChangeState()
        {
            // Arrange
            var sprint = new Sprints.Sprint
            {
                BacklogItems = new List<BacklogItem>()
            };

            // Act
            Tester.TestItem("NonExistentItem", sprint);

            // Assert
            // No state change, so no assertions needed
        }

        [Fact]
        public void TestItem_ItemNotInTestingState_ShouldNotChangeState()
        {
            // Arrange
            var backlogItem = new BacklogItem
            {
                Title = "TestItem",
                State = BacklogItemState.ToDo,
                Assignee = CreateMockUser(),
                Activities = new List<Activity>()
            };

            var sprint = new Sprints.Sprint
            {
                BacklogItems = new List<BacklogItem> { backlogItem }
            };

            // Act
            Tester.TestItem("TestItem", sprint);

            // Assert
            Assert.Equal(BacklogItemState.ToDo, backlogItem.State);
        }

        [Fact]
        public void TestItem_ItemNotCompleted_ShouldChangeStateToToDo()
        {
            // Arrange
            var backlogItem = new BacklogItem
            {
                Title = "TestItem",
                State = BacklogItemState.ReadyForTesting,
                IsCompleted = false,
                Assignee = CreateMockUser(),
                Activities = new List<Activity>()
            };

            var sprint = new Sprints.Sprint
            {
                BacklogItems = new List<BacklogItem> { backlogItem }
            };

            // Act
            Tester.TestItem("TestItem", sprint);

            // Assert
            Assert.Equal(BacklogItemState.ToDo, backlogItem.State);
        }

        [Fact]
        public void TestItem_ItemCompleted_ShouldChangeStateToTested()
        {
            // Arrange
            var backlogItem = new BacklogItem
            {
                Title = "TestItem",
                State = BacklogItemState.ReadyForTesting,
                IsCompleted = true,
                Assignee = CreateMockUser(),
                Activities = new List<Activity>()
            };

            var sprint = new Sprints.Sprint
            {
                BacklogItems = new List<BacklogItem> { backlogItem }
            };

            // Act
            Tester.TestItem("TestItem", sprint);

            // Assert
            Assert.Equal(BacklogItemState.Tested, backlogItem.State);
        }
    }
}
