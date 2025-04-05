namespace DevOps.Persons
{
    public class Developer : User
    {
        public void CompleteItem(string ItemName, Sprints.Sprint sprint)
        {
            var item = sprint.BacklogItems.FirstOrDefault(i => i.Title == ItemName);
            if (item != null)
            {
                if (item.State != BacklogItems.BacklogItemState.Tested)
                {
                    Console.WriteLine("Item is not in tested state");
                    return;
                }

                if (item.IsCompleted)
                {
                    item.ChangeState(BacklogItems.BacklogItemState.Done);
                    Console.WriteLine("Item is  completed");
                }
                else
                {
                    item.ChangeState(BacklogItems.BacklogItemState.ReadyForTesting);
                    Console.WriteLine("Item is not completed");
                }
            } 
        }
    }
}
