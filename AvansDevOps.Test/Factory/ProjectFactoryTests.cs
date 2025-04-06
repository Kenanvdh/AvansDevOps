using System;
using DevOps.Factory;
using Xunit;

namespace AvansDevOps.Test.Factory
{
    public class ProjectFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnProjectWithCorrectProperties()
        {
            // Arrange
            var factory = new ProjectFactory();
            string expectedName = "Test Project";
            DateOnly expectedStartDate = new DateOnly(2025, 1, 1);
            DateOnly expectedEndDate = new DateOnly(2025, 12, 31);
            int expectedVersion = 1;

            // Act
            var project = factory.Create(expectedName, expectedStartDate, expectedEndDate);

            // Assert
            Assert.NotNull(project);
            Assert.Equal(expectedName, project.Name);
            Assert.Equal(expectedStartDate, project.StartDate);
            Assert.Equal(expectedEndDate, project.EndDate);
            Assert.Equal(expectedVersion, project.Version);
        }
    }
}
