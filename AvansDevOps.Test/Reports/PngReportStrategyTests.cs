using DevOps.Sprints;
using Moq;
using Report;
using System;
using Xunit;

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
        public void GenerateReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pngReportStrategy = this.CreatePngReportStrategy();
            Sprint sprint = null;

            // Act
            pngReportStrategy.GenerateReport(
                sprint);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
