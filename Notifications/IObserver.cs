namespace Notifications
{
    public interface IObserver
    {
        public void Update(NotificationSubject service);
    }
}
