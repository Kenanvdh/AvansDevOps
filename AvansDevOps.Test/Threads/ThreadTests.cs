using DevOps.Persons;
using Moq;
using Threads;
using Thread = Threads.Thread;

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
            this.mockUser.Setup(u => u.Name).Returns("TestUser");
        }

        private Thread CreateThread(string content = "This is a thread")
        {
            return new Thread(content, this.mockUser.Object);
        }

        [Fact]
        public void Add_AddsComponent_WhenThreadIsOpen()
        {
            // Arrange
            var thread = this.CreateThread();
            var message = new Message("This is a message", mockUser.Object);

            // Act
            thread.Add(message);

            // Assert: Capture output to check display
            using var sw = new StringWriter();
            Console.SetOut(sw);

            thread.Display(0);
            var output = sw.ToString();

            Assert.Contains("Thread by TestUser: This is a thread", output);
            Assert.Contains("Message by TestUser: This is a message", output);
        }

        [Fact]
        public void Add_CannotAddComponent_WhenThreadIsClosed()
        {
            // Arrange
            var thread = this.CreateThread();
            var message = new Message("This is a message", mockUser.Object);
            thread.CloseThread(); // Close the thread

            // Act: Try to add a component
            thread.Add(message);

            // Assert: Capture output to check error message
            using var sw = new StringWriter();
            Console.SetOut(sw);

            thread.Display(0);
            var output = sw.ToString();

            // Ensure we see the error about the thread being closed
            Assert.Contains("Cannot add a message. The thread is closed.", output);
            Assert.DoesNotContain("Message by TestUser: This is a message", output);
        }

        [Fact]
        public void Remove_RemovesComponentSuccessfully()
        {
            // Arrange
            var thread = this.CreateThread();
            var message = new Message("This is a message", mockUser.Object);
            thread.Add(message); // Add a message

            // Act
            thread.Remove(message);

            // Assert: Capture output to check that message was removed
            using var sw = new StringWriter();
            Console.SetOut(sw);

            thread.Display(0);
            var output = sw.ToString();

            Assert.Contains("Thread by TestUser: This is a thread", output);
            Assert.DoesNotContain("Message by TestUser: This is a message", output);
        }

        [Fact]
        public void Display_PrintsCorrectThreadAndMessageDetails()
        {
            // Arrange
            var thread = this.CreateThread("Main thread content");
            var message = new Message("Reply message", mockUser.Object);
            thread.Add(message);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            thread.Display(2);

            // Assert: Ensure the correct format is printed
            var output = sw.ToString();
            Assert.Contains("-- Thread by TestUser: Main thread content", output);
            Assert.Contains("--- Message by TestUser: Reply message", output);
        }

        [Fact]
        public void CloseThread_ChangesThreadStateToClosed()
        {
            // Arrange
            var thread = this.CreateThread();

            // Act
            thread.CloseThread();

            // Assert: Capture output and verify thread is closed
            using var sw = new StringWriter();
            Console.SetOut(sw);

            thread.Display(0);
            var output = sw.ToString();

            Assert.Contains("Thread by TestUser: This is a thread [CLOSED]", output);
        }

        [Fact]
        public void OpenThread_ChangesThreadStateToOpen()
        {
            // Arrange
            var thread = this.CreateThread();
            thread.CloseThread(); // Close it first

            // Act
            thread.openThread();

            // Assert: Capture output and verify thread is reopened
            using var sw = new StringWriter();
            Console.SetOut(sw);

            thread.Display(0);
            var output = sw.ToString();

            Assert.Contains("Thread by TestUser: This is a thread", output);
            Assert.DoesNotContain("[CLOSED]", output);
        }
    }
}
