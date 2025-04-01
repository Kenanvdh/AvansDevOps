using AvansDevOps.Domain;
using System.Reflection.Metadata;

namespace DevOps.BacklogItems
{
    public class BacklogItem
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private List<Activity> Activities { get; set; }
        private User assignee { get; set; }
        private BacklogItemState State { get; set; }

        public void ChangeState(BacklogItemState state)
        {
            State = state;
            Console.WriteLine($"State changed to {state}");
        }

        public void AddAssignee(User user)
        {
            assignee = user;
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }
    }
}
