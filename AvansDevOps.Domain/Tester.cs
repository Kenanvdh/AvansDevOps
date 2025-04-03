using DevOps.Sprints;

namespace AvansDevOps.Domain
{
    public class Tester : User
    {
        public void CompleteTest(string itemName, string? activityName, Sprint sprint)
        {            
            var item = sprint.BacklogItems.FirstOrDefault(i => i.Title == itemName);
            var activity = item.Activities.FirstOrDefault(a => a.Name == activityName);

            if(item.State != BacklogItemState.Testing)
            {
                Console.WriteLine("Item is not in testing state");
            }
        }
    }
}
