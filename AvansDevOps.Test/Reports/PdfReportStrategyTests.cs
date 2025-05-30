﻿using DevOps.Persons;
using DevOps.Sprints;
using Moq;
using Report;

namespace AvansDevOps.Test.Reports
{
    public class PdfReportStrategyTests
    {
        private PdfReportStrategy CreatePdfReportStrategy()
        {
            return new PdfReportStrategy();
        }

        private Sprint CreateSprint(string name, DateOnly startDate, DateOnly endDate)
        {
            return new Sprint()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate
            };
        }

        [Fact]
        public void GenerateReport_ExpectedBehavior()
        {
            // Arrange
            var pdfReportStrategy = this.CreatePdfReportStrategy();
            Sprint sprint = this.CreateSprint("Sprint 3", new DateOnly(2025, 4, 1), new DateOnly(2025, 4, 8));

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            pdfReportStrategy.GenerateReport(sprint);

            // Assert
            var output = consoleOutput.ToString().Trim();
            Assert.Equal("Generated PDF-report for sprint Sprint 3", output);
        }
    }
}
