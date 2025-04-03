namespace Notifications
{
    public class NotificationSubject : ISubject
    {
        private List<IObserver> Observers;

        protected NotificationSubject()
        {
            Observers = new List<IObserver>();
        }

        public void Register(IObserver observer)
        {
            if (Observers.Contains(observer))
            {
                Console.WriteLine("Observer already exists.");
                return;
            }
            Observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            if (!Observers.Contains(observer))
            {
                Console.WriteLine("Observer doesn't exist.");
            }

            Observers.Remove(observer);
        }

        public void Notify()
        {
            Observers.ForEach(o => o.Update(this));
        }

        public List<IObserver> GetObservers()
        {
            throw new NotImplementedException();
        }
    }
}
