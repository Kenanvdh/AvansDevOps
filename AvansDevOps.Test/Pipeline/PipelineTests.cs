using DevOps.BacklogItems;
using DevOps.Persons;
using DevOps.Pipeline;
using DevOps.Sprints;
using DevOps;
using Moq;
using Xunit;
using Pipeline;

namespace AvansDevOps.Test.Pipeline
{
    public class PipelineTests
    {
        private MockRepository mockRepository;

        public PipelineTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private DevOps.Pipeline.Pipeline CreatePipeline()
        {
            return new DevOps.Pipeline.Pipeline();
        }

        private Sprint CreateSprint()
        {
            return new Sprint
            {
                Name = "Sprint 1",
                StartDate = new DateOnly(2023, 1, 1),
                EndDate = new DateOnly(2023, 1, 15),
                BacklogItems = new List<BacklogItem>(),
                State = SprintState.Planned,
                SprintMaster = new Mock<User>().Object,
                Project = new Project { Name = "Project 1" }
            };
        }

        [Fact]
        public void Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pipeline = this.CreatePipeline();
            var sprint = this.CreateSprint();

            // Act
            pipeline.Start(sprint);

            // Assert
            // Add assertions to verify the expected behavior
            Assert.NotNull(sprint);
            Assert.Equal("Sprint 1", sprint.Name);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void SetState_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pipeline = this.CreatePipeline();
            var mockState = new Mock<IPipelineState>();
            IPipelineState state = mockState.Object;

            // Act
            pipeline.SetState(state);

            // Assert
            mockState.Verify(s => s.Execute(pipeline), Times.Once);
            this.mockRepository.VerifyAll();
        }

    }
}
