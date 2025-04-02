namespace Notificator
{
    public class NotificationService : ISubject
    {
        private List<IObserver> Observers { get; set; }

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
