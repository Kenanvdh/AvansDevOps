public class SprintTests
{
    [Fact]
    public void UpdateSprintState_ShouldChangeState_WhenNameMatches()
    {
        // Arrange
        var sprint = new Sprint { Name = "Sprint 1" };
        var newState = SprintState.InProgress;

        // Act
        sprint.UpdateSprintState("Sprint 1", newState);

        // Assert
        Assert.Equal(newState, sprint.State);
    }

}
