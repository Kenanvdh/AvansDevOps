using DevOps.Sprint.Templates;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class ReviewSprintTemplateTests
    {
        private MockRepository mockRepository;



        public ReviewSprintTemplateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ReviewSprintTemplate CreateReviewSprintTemplate()
        {
            return new ReviewSprintTemplate();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var reviewSprintTemplate = this.CreateReviewSprintTemplate();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
