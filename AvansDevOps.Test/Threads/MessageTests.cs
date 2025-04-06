using DevOps.Persons;
using Moq;
using System;
using Threads;
using Xunit;

namespace AvansDevOps.Test.Threads
{
    public class MessageTests
    {
        private MockRepository mockRepository;

        private Mock<User> mockUser;

        public MessageTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUser = this.mockRepository.Create<User>();
        }

        private Message CreateMessage()
        {
            return new Message(
                TODO,
                this.mockUser.Object);
        }

        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var message = this.CreateMessage();
            ThreadComponent component = null;

            // Act
            message.Add(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var message = this.CreateMessage();
            ThreadComponent component = null;

            // Act
            message.Remove(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Display_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var message = this.CreateMessage();
            int depth = 0;

            // Act
            message.Display(
                depth);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
