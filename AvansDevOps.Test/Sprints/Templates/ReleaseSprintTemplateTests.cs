using DevOps.Sprint.Templates;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test.Sprints.Templates
{
    public class ReleaseSprintTemplateTests
    {
        private MockRepository mockRepository;



        public ReleaseSprintTemplateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ReleaseSprintTemplate CreateReleaseSprintTemplate()
        {
            return new ReleaseSprintTemplate(
                TODO);
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var releaseSprintTemplate = this.CreateReleaseSprintTemplate();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
