using DevOps.Sprints;
using Moq;
using Report;
using Xunit;

namespace AvansDevOps.Test.Reports
{
    public class ReportGeneratorTests
    {
        [Fact]
        public void SetStrategy_SetsCorrectStrategy()
        {
            // Arrange
            var reportGenerator = new ReportGenerator();
            var mockStrategy = new Mock<IReportStrategy>();

            // Act
            reportGenerator.SetStrategy(mockStrategy.Object);

            // Assert: Verify the strategy is set correctly
            Assert.NotNull(reportGenerator.ReportStrategy);
            Assert.Equal(mockStrategy.Object, reportGenerator.ReportStrategy);
        }

        [Fact]
        public void GenerateReport_CallsGenerateReportOnStrategy()
        {
            // Arrange
            var reportGenerator = new ReportGenerator();
            var mockStrategy = new Mock<IReportStrategy>();
            var sprint = new Sprint { Name = "Sprint 1" };

            // Set the strategy
            reportGenerator.SetStrategy(mockStrategy.Object);

            // Act
            reportGenerator.GenerateReport(sprint);

            // Assert: Verify GenerateReport was called on the strategy
            mockStrategy.Verify(strategy => strategy.GenerateReport(sprint), Times.Once);
        }

        [Fact]
        public void GenerateReport_DoesNotCallGenerateReport_WhenNoStrategySet()
        {
            // Arrange
            var reportGenerator = new ReportGenerator();
            var mockStrategy = new Mock<IReportStrategy>();
            var sprint = new Sprint { Name = "Sprint 1" };

            // Act
            reportGenerator.GenerateReport(sprint);

            // Assert: Verify GenerateReport was not called when no strategy is set
            mockStrategy.Verify(strategy => strategy.GenerateReport(sprint), Times.Never);
        }
    }
}
