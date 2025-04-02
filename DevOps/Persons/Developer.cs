namespace DevOps.Persons
{
    public class Developer : User
    {
        public void CompleteItem(string ItemName, Sprints.Sprint sprint)
        {
            var item = sprint.BacklogItems.FirstOrDefault(i => i.Title == ItemName);
            if (item.State != BacklogItems.BacklogItemState.Tested)
            {
                Console.WriteLine("Item is not in tested state");
                return;
            }
            item.ChangeState(BacklogItems.BacklogItemState.Done);
        }
    }
}
