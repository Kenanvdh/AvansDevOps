
using DevOps.BacklogItems;

namespace Notifications
{
    public class BacklogItemObserver : IObserver
    {
        public void Update(NotificationSubject subject)
        {
            if (!(subject is BacklogItem backlogItem)) return;

        }
    }
}
