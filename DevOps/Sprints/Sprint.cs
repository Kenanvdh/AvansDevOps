using DevOps.BacklogItems;

namespace DevOps.Sprints
{
    public class Sprint
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        private List<BacklogItem> BacklogItems { get; set; }
        public SprintState State { get; set; }

        public Sprint() { }

        public void UpdateSprintState(string name, SprintState state)
        {
            if (Name == name)
            {
                State = state;
                Console.WriteLine($"Sprint {name} state changed to {state}");
            }
        }

        public void FinishSprint(string name)
        {
            if (Name == name && EndDate < DateOnly.FromDateTime(DateTime.Now))
            {
                State = SprintState.Finished;
                Console.WriteLine($"Sprint {name} finished.");
            }
        }
    }
}
