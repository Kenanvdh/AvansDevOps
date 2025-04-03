
namespace DevOps.BacklogItems
{
    public class BacklogItem : NotificationSubject
    {
        public string Title { get; set; }
        private string Description { get; set; }
        public List<Activity> Activities { get; set; }
        private Persons.User assignee { get; set; }
        public BacklogItemState State { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsApproved { get; set; }

        public void CreateItem(string title, string description)
        {
            Title = title;
            Description = description;
            Activities = new List<Activity>();
            State = BacklogItemState.ToDo;
        }

        public void ChangeState(BacklogItemState state)
        {
            State = state;
            Console.WriteLine($"State changed to {state}");
        }

        public void AddAssignee(Persons.User user)
        {
            assignee = user;
        }

        public void AddMoreAssignees(List<Persons.User> users, string activityTitle, string activityDescription)
        {
            foreach (Persons.User user in users)
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
            State = BacklogItemState.ReadyForTesting;
        }
    }
}
