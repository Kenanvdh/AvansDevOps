using Xunit;
using System;
using System.IO;
using DevOps.Persons;
using Threads;

namespace Threads.Tests
{
    public class ThreadTests
    {
        private class MockUser : User
        {
            public MockUser(string name)
            {
                Name = name;
            }
        }

        [Fact]
        public void Thread_CanAddMessage_WhenOpen()
        {
            var user = new MockUser("Alice");
            var thread = new Threads.Thread("Main thread", user); // <== Let op dit verschil
            var message = new Message("Reply message", user);

            thread.Add(message);

            var sw = new StringWriter();
            Console.SetOut(sw);
            thread.Display(0);

            var output = sw.ToString();
            Assert.Contains("Main thread", output);
            Assert.Contains("Reply message", output);
        }

        [Fact]
        public void Thread_CannotAddMessage_WhenClosed()
        {
            var user = new MockUser("Bob");
            var thread = new Threads.Thread("Closed thread", user);
            var message = new Message("Should not be added", user);

            thread.CloseThread();
            var sw = new StringWriter();
            Console.SetOut(sw);
            thread.Add(message);

            var output = sw.ToString();
            Assert.Contains("Cannot add a message. The thread is closed.", output);

            sw.GetStringBuilder().Clear();
            thread.Display(0);
            output = sw.ToString();
            Assert.DoesNotContain("Should not be added", output);
            Assert.Contains("[CLOSED]", output);
        }

        [Fact]
        public void Thread_CanReopen_AndAddMessages()
        {
            var user = new MockUser("Charlie");
            var thread = new Threads.Thread("Thread test", user);
            thread.CloseThread();
            thread.openThread();

            var message = new Message("New message after reopen", user);
            thread.Add(message);

            var sw = new StringWriter();
            Console.SetOut(sw);
            thread.Display(0);

            var output = sw.ToString();
            Assert.Contains("New message after reopen", output);
            Assert.DoesNotContain("[CLOSED]", output);
        }

        [Fact]
        public void Thread_CanRemoveMessage()
        {
            var user = new MockUser("Dana");
            var thread = new Threads.Thread("Thread root", user);
            var msg = new Message("To be removed", user);
            thread.Add(msg);
            thread.Remove(msg);

            var sw = new StringWriter();
            Console.SetOut(sw);
            thread.Display(0);

            var output = sw.ToString();
            Assert.DoesNotContain("To be removed", output);
        }
    }
}
