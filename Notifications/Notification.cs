using DevOps.Persons;

namespace Notifications
{
    public class Notification
    {
        public string Message { get; set; }
        public User Recipient { get; set; }

        public void SendNotification()
        {
            // Send notification
        }
    }
}
