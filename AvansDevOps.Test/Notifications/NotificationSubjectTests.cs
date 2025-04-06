using System;
using System.Collections.Generic;
using Moq;
using Moq.Protected;
using Notifications;
using Xunit;

namespace AvansDevOps.Test.Notifications
{
    public class NotificationSubjectTests
    {

        [Fact]
        public void Register_ShouldAddObserver()
        {
            // Arrange
            var subject = new Mock<NotificationSubject>() { CallBase = true };
            var observerMock = new Mock<IObserver>();

            // Act
            subject.Object.Register(observerMock.Object);
            subject.Object.Notify();

            // Assert
            observerMock.Verify(o => o.Update(subject.Object), Times.Once);
        }


        [Fact]
        public void Register_ShouldNotAddDuplicateObserver()
        {
            // Arrange
            var subject = new Mock<NotificationSubject>() { CallBase = true };
            var observerMock = new Mock<IObserver>();

            subject.Object.Register(observerMock.Object);
            subject.Object.Register(observerMock.Object);

            // Act
            subject.Object.Notify();

            // Assert
            observerMock.Verify(o => o.Update(subject.Object), Times.Once); // only called once
        }


        [Fact]
        public void Unregister_ShouldRemoveObserver()
        {
            // Arrange
            var subject = new Mock<NotificationSubject>() { CallBase = true };
            var observerMock = new Mock<IObserver>();

            subject.Object.Register(observerMock.Object);
            subject.Object.Unregister(observerMock.Object);

            // Act
            subject.Object.Notify();

            // Assert
            observerMock.Verify(o => o.Update(subject.Object), Times.Never);
        }


        [Fact]
        public void Notify_ShouldCallUpdateOnObservers()
        {
            // Arrange
            var subject = new Mock<NotificationSubject>() { CallBase = true };
            var observerMock = new Mock<IObserver>();
            subject.Object.Register(observerMock.Object);

            // Act
            subject.Object.Notify();

            // Assert
            observerMock.Verify(o => o.Update(subject.Object), Times.Once);
        }

    }
}
