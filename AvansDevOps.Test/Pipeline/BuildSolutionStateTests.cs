using DevOps.Pipeline;
using Moq;
using Pipeline;
using System;
using Xunit;

namespace AvansDevOps.Test.Pipeline
{
    public class BuildSolutionStateTests
    {
        private MockRepository mockRepository;

        public BuildSolutionStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private BuildSolutionState CreateBuildSolutionState()
        {
            return new BuildSolutionState();
        }

        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var buildSolutionState = this.CreateBuildSolutionState();
            var mockPipeline = new Mock<IPipeline>();
            IPipeline pipeline = mockPipeline.Object;

            // Define the expected behavior for the mock pipeline
            mockPipeline.Setup(p => p.SetState(It.IsAny<IPipelineState>())).Verifiable();

            // Act
            buildSolutionState.Execute(pipeline);

            // Assert
            mockPipeline.Verify(p => p.SetState(It.IsAny<IPipelineState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}


