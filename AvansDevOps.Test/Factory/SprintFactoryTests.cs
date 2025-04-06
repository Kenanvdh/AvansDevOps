using System;
using DevOps.Factory;
using DevOps.Sprints;
using Xunit;

namespace AvansDevOps.Test.Factory
{
    public class SprintFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnSprintWithCorrectProperties()
        {
            // Arrange
            var factory = new SprintFactory();
            string name = "Sprint 1";
            DateOnly startDate = new DateOnly(2025, 4, 1);
            DateOnly endDate = new DateOnly(2025, 4, 15);

            // Act
            Sprint sprint = factory.Create(name, startDate, endDate);

            // Assert
            Assert.NotNull(sprint);
            Assert.Equal(name, sprint.Name);
            Assert.Equal(startDate, sprint.StartDate);
            Assert.Equal(endDate, sprint.EndDate);
        }
    }
}
