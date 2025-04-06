using DevOps.Sprints;
using Moq;
using Report;

namespace AvansDevOps.Test.Reports
{
    public class PngReportStrategyTests
    {
        private MockRepository mockRepository;

        public PngReportStrategyTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private PngReportStrategy CreatePngReportStrategy()
        {
            return new PngReportStrategy();
        }

        [Fact]
        public void GenerateReport_xpectedBehavior()
        {
            // Arrange
            var pngReportStrategy = this.CreatePngReportStrategy();
            Sprint sprint = null;

            // Act
            pngReportStrategy.GenerateReport(sprint);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
