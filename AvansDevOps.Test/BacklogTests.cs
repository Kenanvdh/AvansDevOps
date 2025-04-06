using DevOps;
using DevOps.BacklogItems;
using Moq;
using System;
using Xunit;

namespace AvansDevOps.Test
{
    public class BacklogTests
    {
        private MockRepository mockRepository;



        public BacklogTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Backlog CreateBacklog()
        {
            return new Backlog();
        }

        [Fact]
        public void AddItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var backlog = this.CreateBacklog();
            BacklogItem item = null;

            // Act
            backlog.AddItem(
                item);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
