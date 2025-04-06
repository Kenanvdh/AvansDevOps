using DevOps.Pipeline;
using Moq;
using Pipeline;
using System;
using Xunit;

namespace AvansDevOps.Test.Pipeline
{
    public class TestSolutionStateTests
    {
        private MockRepository mockRepository;

        public TestSolutionStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private TestSolutionState CreateTestSolutionState()
        {
            return new TestSolutionState();
        }

        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var testSolutionState = this.CreateTestSolutionState();
            var mockPipeline = new Mock<IPipeline>();
            IPipeline pipeline = mockPipeline.Object;

            // Define the expected behavior for the mock pipeline
            mockPipeline.Setup(p => p.SetState(It.IsAny<IPipelineState>())).Verifiable();

            // Act
            testSolutionState.Execute(pipeline);

            // Assert
            mockPipeline.Verify(p => p.SetState(It.IsAny<IPipelineState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}
