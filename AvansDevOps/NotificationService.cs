namespace Notificator
{
    public class NotificationService : IObserver
    {
        private List<IObserver> Observers { get; set; }

        public void addObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void NotifyObservers()
        {
            
        }

        public void Update()
        {

        }
    }
}
