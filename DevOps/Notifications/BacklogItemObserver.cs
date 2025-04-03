using DevOps.BacklogItems;
using DevOps.Persons;

namespace Notifications
{
    public class BacklogItemObserver : IObserver
    {
        public void Update(NotificationSubject subject)
        {
            if (!(subject is BacklogItem backlogItem))
            {
                return;
                }

            switch (backlogItem.State)
            {
                case BacklogItemState.ToDo:
                    ToDoNotify(backlogItem);
                    break;
                case BacklogItemState.Doing:
                    DoingNotify(backlogItem);
                    break;
                case BacklogItemState.ReadyForTesting:
                    ReadyForTestingNotify(backlogItem);
                    break;
                case BacklogItemState.Testing:
                    TestingNotify(backlogItem);
                    break;
                case BacklogItemState.Tested:
                    TestedNotify(backlogItem);
                    break;
                case BacklogItemState.Done:
                    DoneNotiify(backlogItem);
                    break;
            }
        }

        private void ToDoNotify(BacklogItem item)
        {
            var scrumMaster = item.GetSprint().SprintMaster;
            scrumMaster.SendMessage(scrumMaster.Name, $"Backlog item {item.Title} is in ToDo state.");
        }

        private void DoingNotify(BacklogItem item)
        {
            var tempList = new List<User>();

            if (item.Activities != null)
            {
                foreach (var activity in item.Activities)
                {
                    tempList.Add(activity.Assignee);
                }
            }

            if(item.Assignee != null)
            {
                tempList.Add(item.Assignee);
            }

            foreach (var user in tempList)
            {
                user.SendMessage(user.Name, $"Backlog item {item.Title} is in Doing state.");
            }
        }

        private void ReadyForTestingNotify(BacklogItem item)
        {
            var testers = item.GetSprint().GetProject().Testers;
            foreach (var tester in testers)
            {
                tester.SendMessage(tester.Name, $"Backlog item {item.Title} is in ReadyForTesting state.");
            }
        }

        private void TestingNotify(BacklogItem item)
        {
            var scrumMaster = item.GetSprint().SprintMaster;
            scrumMaster.SendMessage(scrumMaster.Name, $"Backlog item {item.Title} is in Testing state.");
        }

        private void TestedNotify(BacklogItem item)
        {
            var scrumMaster = item.GetSprint().SprintMaster;
            scrumMaster.SendMessage(scrumMaster.Name, $"Backlog item {item.Title} is in Tested state.");

            foreach (var tester in item.GetSprint().GetProject().Testers)
            {
                tester.SendMessage(tester.Name, $"Backlog item {item.Title} is in Tested state.");
            }
        }

        private void DoneNotiify(BacklogItem item)
        {
            var scrumMaster = item.GetSprint().SprintMaster;
            scrumMaster.SendMessage(scrumMaster.Name, $"Backlog item {item.Title} is in Done state.");

            var tempList = new List<User>();

            if (item.Activities != null)
            {
                foreach (var activity in item.Activities)
                {
                    tempList.Add(activity.Assignee);
                }
            }

            if (item.Assignee != null)
            {
                tempList.Add(item.Assignee);
            }

            foreach (var user in tempList)
            {
                user.SendMessage(user.Name, $"Backlog item {item.Title} is in Done state.");
            }
        }
    }
}
