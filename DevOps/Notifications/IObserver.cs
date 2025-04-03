using DevOps.BacklogItems;

namespace Notifications
{
    public interface IObserver
    {
        public void Update(NotificationSubject subject);
    }
}
