using DevOps.Sprint.Templates;
using DevOps.Sprints;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class FailedSprintTemplateTests
    {
        private MockRepository mockRepository;



        public FailedSprintTemplateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private FailedSprintTemplate CreateFailedSprintTemplate()
        {
            return new FailedSprintTemplate();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var failedSprintTemplate = this.CreateFailedSprintTemplate();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
