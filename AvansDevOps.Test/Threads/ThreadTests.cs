using DevOps.Persons;
using Moq;
using System;
using Threads;
using Xunit;

namespace AvansDevOps.Test.Threads
{
    public class ThreadTests
    {
        private MockRepository mockRepository;

        private Mock<User> mockUser;

        public ThreadTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUser = this.mockRepository.Create<User>();
        }

        private Thread CreateThread()
        {
            return new Thread(
                TODO,
                this.mockUser.Object);
        }

        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var thread = this.CreateThread();
            ThreadComponent component = null;

            // Act
            thread.Add(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var thread = this.CreateThread();
            ThreadComponent component = null;

            // Act
            thread.Remove(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Display_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var thread = this.CreateThread();
            int depth = 0;

            // Act
            thread.Display(
                depth);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CloseThread_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var thread = this.CreateThread();

            // Act
            thread.CloseThread();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void openThread_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var thread = this.CreateThread();

            // Act
            thread.openThread();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
