using AvansDevOps.Domain;

namespace DevOps.BacklogItems
{
    public class BacklogItem
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private List<Activity> Activities { get; set; }
        private User assignee { get; set; }
        private BacklogItemState State { get; set; }

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

        public void AddAssignee(User user)
        {
            assignee = user;
        }

        public void AddMoreAssignees(List<User> users, string activityTitle, string activityDescription)
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
        }
    }
}
