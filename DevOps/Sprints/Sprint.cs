using DevOps.BacklogItems;
using DevOps.Persons;

namespace DevOps.Sprints
{
    public class Sprint
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public SprintState State { get; set; }
        public User SprintMaster { get; set; }
        public Project Project { get; set; }
        public Sprint() { }
                
        public void ChangeSprintInfo(string name, DateOnly startDate, DateOnly endDate)
        {
            if (Name == name && State != SprintState.InProgress)
            {
                Name = name;
                StartDate = startDate;
                EndDate = endDate;
                Console.WriteLine($"Sprint {name} info changed.");
            }
        }

        public Project GetProject()
        {
            return Project;
        }

        public void StartSprint(string name)
        {
            if(Name == name && StartDate < DateOnly.FromDateTime(DateTime.Now))
            {
                State = SprintState.InProgress;

                foreach(BacklogItem item in BacklogItems)
                {
                    item.ChangeState(BacklogItemState.ToDo);
                }

                Console.WriteLine($"Sprint {name} started.");
            }
        }

        public void UpdateSprintState(string name, SprintState state)
        {
            if (Name == name)
            {
                State = state;
                Console.WriteLine($"Sprint {name} state changed to {state}");
            }
        }

        public void AddBacklogItem(string sprintName, BacklogItem item)
        {
            if (Name == sprintName)
            {
                BacklogItems.Add(item);
            }
            else
            {
                Console.WriteLine($"Sprint {sprintName} not found.");
            }
        }

        public List<BacklogItem> GetItems()
        {
            return BacklogItems;
        }
    }
}
