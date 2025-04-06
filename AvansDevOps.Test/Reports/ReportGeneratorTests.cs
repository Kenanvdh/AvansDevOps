using DevOps.Sprints;
using Moq;
using Report;
using System;
using Xunit;

namespace AvansDevOps.Test.Reports
{
    public class ReportGeneratorTests
    {
        private MockRepository mockRepository;



        public ReportGeneratorTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ReportGenerator CreateReportGenerator()
        {
            return new ReportGenerator();
        }

        [Fact]
        public void SetStrategy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportGenerator = this.CreateReportGenerator();
            IReportStrategy reportStrategy = null;

            // Act
            reportGenerator.SetStrategy(
                reportStrategy);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GenerateReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportGenerator = this.CreateReportGenerator();
            Sprint sprint = null;

            // Act
            reportGenerator.GenerateReport(
                sprint);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
