using DevOps.Pipeline;
using Moq;
using Pipeline;
using System;
using Xunit;

namespace AvansDevOps.Test.Pipeline
{
    public class DeployStateTests
    {
        private MockRepository mockRepository;

        public DeployStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private DeployState CreateDeployState()
        {
            return new DeployState();
        }

        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var deployState = this.CreateDeployState();
            var mockPipeline = new Mock<IPipeline>();
            IPipeline pipeline = mockPipeline.Object;

            // Define the expected behavior for the mock pipeline
            mockPipeline.Setup(p => p.SetState(It.IsAny<IPipelineState>())).Verifiable();

            // Act
            deployState.Execute(pipeline);

            // Assert
            mockPipeline.Verify(p => p.SetState(It.IsAny<IPipelineState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}

