using DevOps.Sprints;
using Moq;
using Report;

namespace AvansDevOps.Test.Reports
{
    public class PdfReportStrategyTests
    {
        private MockRepository mockRepository;

        public PdfReportStrategyTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private PdfReportStrategy CreatePdfReportStrategy()
        {
            return new PdfReportStrategy();
        }

        [Fact]
        public void GenerateReport_ExpectedBehavior()
        {
            // Arrange
            var pdfReportStrategy = this.CreatePdfReportStrategy();
            Sprint sprint = null;

            // Act
            pdfReportStrategy.GenerateReport(sprint);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
