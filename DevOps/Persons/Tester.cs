﻿namespace DevOps.Persons
{
    public class Tester : User
    {
        public void TestItem(string itemName, Sprints.Sprint sprint)
        {
            var item = sprint.BacklogItems.FirstOrDefault(i => i.Title == itemName);

            if (item.State != BacklogItems.BacklogItemState.ReadyForTesting)
            {
                Console.WriteLine("Item is not in testing state");
                return;
            }

            if (!item.IsCompleted)
            {
                item.ChangeState(BacklogItems.BacklogItemState.ToDo);
                Console.WriteLine("Item is not completed");
            }
            else
            {
                item.ChangeState(BacklogItems.BacklogItemState.Tested);
                Console.WriteLine("Item is in progress");
            }
        }
    }
}
