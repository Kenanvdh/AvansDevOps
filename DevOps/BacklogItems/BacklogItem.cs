using Notifications;
using Threads;
using DevOps.Persons;


namespace DevOps.BacklogItems
{
    public class BacklogItem : NotificationSubject
    {
        public required string Title { get; set; }
        private string Description { get; set; } = string.Empty;
        public required List<Activity> Activities { get; set; } 
        public required User Assignee { get; set; }
        public required BacklogItemState State { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsApproved { get; set; }
        private Sprints.Sprint Sprint { get; } = new Sprints.Sprint();
        private Threads.Thread? discussionThread { get; set; } 

        public void CreateItem(string title, string description)
        {
            Title = title;
            Description = description;
            Activities = new List<Activity>();
            State = BacklogItemState.ToDo;
        }

        public Sprints.Sprint GetSprint()
        {
            return Sprint;
        }

        public void ChangeState(BacklogItemState state)
        {
            State = state;
            Console.WriteLine($"State changed to {state}");

            if (state != BacklogItemState.Done && discussionThread != null)
            {
                discussionThread.openThread();
                Console.WriteLine($"Thread opened for BacklogItem: {Title}");
            }
        }

        public void AddAssignee(User user)
        {
            Assignee = user;
        }

        public static void AddMoreAssignees(List<User> users, string activityTitle, string activityDescription)
        {
            foreach (User user in users)
            {
                Activity activity = new Activity();
                activity.CreateActivity(activityTitle, activityDescription, user);
            }
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void FinishItem()
        {
            if (Activities.Any(a => !a.MarkCompleted()))
            {
                Console.WriteLine("Not all activities are completed.");
                return;
            }

            State = BacklogItemState.Done;
            Console.WriteLine($"BacklogItem '{Title}' is marked as Done.");

            if (discussionThread != null)
            {
                discussionThread.CloseThread();
            }
        }


        public void StartThread(string message, User user)
        {
            if (State == BacklogItemState.Done)
            {
                Console.WriteLine("Cannot start a thread on a completed BacklogItem.");
                return;
            }

            if (discussionThread != null)
            {
                Console.WriteLine("Thread already exists.");
                return;
            }

            discussionThread = new Threads.Thread(message, user);
            Console.WriteLine($"Thread started by {user.Name} for BacklogItem: {Title}");
        }

        public void AddMessageToThread(string messageContent, User user)
        {
            if (discussionThread == null)
            {
                throw new InvalidOperationException("Cannot add a message: No thread started.");
            }

            discussionThread.Add(new Message(messageContent, user));
            Console.WriteLine($"Message added by {user.Name} to thread.");
        }

        public void AddReplyToMessage(Message originalMessage, string replyContent, User user)
        {
            if (discussionThread == null)
            {
                throw new InvalidOperationException("Cannot add a message: No thread started.");
            }

            Message reply = new Message(replyContent, user);
            originalMessage.Add(reply);
            Console.WriteLine($"Reply added by {user.Name} to message: \"{originalMessage}\".");
        }

        public void DisplayThread()
        {
            if (discussionThread == null)
            {
                throw new InvalidOperationException("No thread exists for BacklogItem: {Title}");
            }

            Console.WriteLine($"Thread for BacklogItem: {Title}");
            discussionThread.Display(1);
        }

    }
}
