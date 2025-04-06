using System;
using System.IO;
using DevOps.Persons;
using Threads;
using Xunit;

namespace Threads.Tests
{
    public class MessageTests
    {
        // Mockklasse om abstracte User te kunnen gebruiken
        private class MockUser : User
        {
            public MockUser(string name)
            {
                Name = name;
            }
        }

        [Fact]
        public void Message_CanAddReply()
        {
            // Arrange
            var user = new MockUser("Alice");
            var message = new Message("Hello world", user);
            var reply = new Message("Hi!", user);

            // Act
            message.Add(reply);

            // Assert
            var sw = new StringWriter();
            Console.SetOut(sw);
            message.Display(0);

            var output = sw.ToString();
            Assert.Contains("Hello world", output);
            Assert.Contains("Hi!", output);
        }

        [Fact]
        public void Message_CanRemoveReply()
        {
            // Arrange
            var user = new MockUser("Bob");
            var message = new Message("Initial", user);
            var reply = new Message("This will be removed", user);
            message.Add(reply);

            // Act
            message.Remove(reply);

            // Assert
            var sw = new StringWriter();
            Console.SetOut(sw);
            message.Display(0);

            var output = sw.ToString();
            Assert.DoesNotContain("This will be removed", output);
        }

        [Fact]
        public void Message_Display_ShowsNestedReplies()
        {
            // Arrange
            var user = new MockUser("Charlie");
            var root = new Message("Root", user);
            var child = new Message("Child", user);
            var grandchild = new Message("Grandchild", user);


            root.Add(child);
            child.Add(grandchild);

            // Act
            var originalOut = Console.Out;
            var sw = new StringWriter();
            Console.SetOut(sw);
            root.Display(0);

            var output = sw.ToString();

            // Assert
            Assert.Contains("Root", output);
            Assert.Contains("Child", output);
            Assert.Contains("Grandchild", output);

            // Herstel output
            Console.SetOut(originalOut);
        }
    }
}
