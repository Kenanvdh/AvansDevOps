using DevOps.Sprints;

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

    [Fact]
    public void FinishSprint_ShouldChangeStateToFinished_WhenConditionsMet()
    {
        // Arrange
        var sprint = new Sprint
        {
            Name = "Sprint 2",
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
        };

        // Act
        sprint.FinishSprint("Sprint 2");

        // Assert
        Assert.Equal(SprintState.Finished, sprint.State);
    }
}
