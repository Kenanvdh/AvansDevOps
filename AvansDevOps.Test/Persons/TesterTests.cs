using DevOps.Persons;
using DevOps.Sprints;
using Xunit;
using Moq;
using System.Collections.Generic;
using DevOps.BacklogItems;

public class TesterTests
{
    [Fact]
    public void TestItem_ItemNotInTestingState_ShouldPrintMessage()
    {
        // Arrange
        var sprint = new Sprint { BacklogItems = new List<BacklogItem> { new BacklogItem { Title = "Item1", State = BacklogItemState.ToDo } } };
        var tester = new Tester();
        var itemName = "Item1";

        // Act
        tester.TestItem(itemName, sprint);

        // Assert
        // Verify the console output or use a mock to verify the method behavior
    }

    [Fact]
    public void TestItem_ItemNotCompleted_ShouldChangeStateToToDo()
    {
        // Arrange
        var backlogItem = new BacklogItem { Title = "Item1", State = BacklogItemState.ReadyForTesting, IsCompleted = false };
        var sprint = new Sprint { BacklogItems = new List<BacklogItem> { backlogItem } };
        var tester = new Tester();
        var itemName = "Item1";

        // Act
        tester.TestItem(itemName, sprint);

        // Assert
        Assert.Equal(BacklogItemState.ToDo, backlogItem.State);
    }

    [Fact]
    public void TestItem_ItemCompleted_ShouldChangeStateToTested()
    {
        // Arrange
        var backlogItem = new BacklogItem { Title = "Item1", State = BacklogItemState.ReadyForTesting, IsCompleted = true };
        var sprint = new Sprint { BacklogItems = new List<BacklogItem> { backlogItem } };
        var tester = new Tester();
        var itemName = "Item1";

        // Act
        tester.TestItem(itemName, sprint);

        // Assert
        Assert.Equal(BacklogItemState.Tested, backlogItem.State);
    }
}
