using DevOps.Sprints;

namespace DevOps.Persons
{
    public class Tester : User
    {
        public void PutBackItem(string itemName, Sprints.Sprint sprint)
        {
            var item = sprint.BacklogItems.FirstOrDefault(i => i.Title == itemName);

            if(item.State != BacklogItems.BacklogItemState.ReadyForTesting)
            {
                Console.WriteLine("Item is not in testing state");
                return;
            }

            item.ChangeState(BacklogItems.BacklogItemState.ToDo);
        }
    }
}
