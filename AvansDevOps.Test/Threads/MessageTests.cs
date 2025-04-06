using DevOps.Persons;
using Moq;
using Threads;
using Xunit;
using System;
using System.IO;

namespace AvansDevOps.Test.Threads
{
    public class MessageTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<User> mockUser;

        public MessageTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockUser = this.mockRepository.Create<User>();
            this.mockUser.Setup(u => u.Name).Returns("TestUser");
        }

        private Message CreateMessage(string content = "This is a message")
        {
            return new Message(content, this.mockUser.Object);
        }

        [Fact]
        public void Add_AddsReplyMessage_Successfully()
        {
            // Arrange
            var parent = CreateMessage("Parent");
            var reply = CreateMessage("Reply");

            // Act
            parent.Add(reply);

            // Assert: Capture output to ensure the reply is part of Display
            using var sw = new StringWriter();
            Console.SetOut(sw);

            parent.Display(0);

            var output = sw.ToString();

            Assert.Contains("Message by TestUser: Parent", output);
            Assert.Contains("-- Message by TestUser: Reply", output);
        }

        [Fact]
        public void Remove_RemovesReplyMessage_Successfully()
        {
            // Arrange
            var parent = CreateMessage("Parent");
            var reply = CreateMessage("Reply");

            parent.Add(reply);

            // Act
            parent.Remove(reply);

            // Assert
            using var sw = new StringWriter();
            Console.SetOut(sw);

            parent.Display(0);

            var output = sw.ToString();

            Assert.Contains("Message by TestUser: Parent", output);
            Assert.DoesNotContain("Reply", output);
        }

        [Fact]
        public void Display_PrintsCorrectFormat()
        {
            // Arrange
            var message = CreateMessage("Hello world");

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            message.Display(2);

            // Assert
            var output = sw.ToString();
            Assert.Contains("-- Message by TestUser: Hello world", output);
        }
    }
}
