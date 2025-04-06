using DevOps.Pipeline;
using Moq;
using Pipeline;
using System;
using Xunit;

namespace AvansDevOps.Test.Pipeline
{
    public class DownloadingSourcesStateTests
    {
        private MockRepository mockRepository;

        public DownloadingSourcesStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private DownloadingSourcesState CreateDownloadingSourcesState()
        {
            return new DownloadingSourcesState();
        }

        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var downloadingSourcesState = this.CreateDownloadingSourcesState();
            var mockPipeline = new Mock<IPipeline>();
            IPipeline pipeline = mockPipeline.Object;

            // Define the expected behavior for the mock pipeline
            mockPipeline.Setup(p => p.SetState(It.IsAny<IPipelineState>())).Verifiable();

            // Act
            downloadingSourcesState.Execute(pipeline);

            // Assert
            mockPipeline.Verify(p => p.SetState(It.IsAny<IPipelineState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}

