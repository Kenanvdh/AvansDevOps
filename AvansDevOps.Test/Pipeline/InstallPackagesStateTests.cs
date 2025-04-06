using DevOps.Pipeline;
using Moq;
using Pipeline;
using System;
using Xunit;

namespace AvansDevOps.Test.Pipeline
{
    public class InstallPackagesStateTests
    {
        private MockRepository mockRepository;

        public InstallPackagesStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private InstallPackagesState CreateInstallPackagesState()
        {
            return new InstallPackagesState();
        }

        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var installPackagesState = this.CreateInstallPackagesState();
            var mockPipeline = new Mock<IPipeline>();
            IPipeline pipeline = mockPipeline.Object;

            // Define the expected behavior for the mock pipeline
            mockPipeline.Setup(p => p.SetState(It.IsAny<IPipelineState>())).Verifiable();

            // Act
            installPackagesState.Execute(pipeline);

            // Assert
            mockPipeline.Verify(p => p.SetState(It.IsAny<IPipelineState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}
