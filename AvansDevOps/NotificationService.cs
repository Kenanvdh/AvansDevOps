using System;

namespace Notificator
{
    public class NotificationService : IObserver
    {
        private List<IObserver> Observers { get; set; }

        public void REgister(IObserver observer)
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

        public void NotifyObservers()
        {
            Observers.ForEach(o => o.Update(this));
        }

        public void Update()
        {

        }
    }
}
