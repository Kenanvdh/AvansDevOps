using DevOps.BacklogItems;
using DevOps.Sprint.State;

namespace DevOps.Sprints
{
    public class Sprint
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        private List<BacklogItem> BacklogItems { get; set; }
        private SprintState State { get; set; }

        public Sprint() { }

        public Sprint(string name, DateOnly startDate, DateOnly endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            BacklogItems = new List<BacklogItem>();
        }

        public void StartSprint()
        {
            // Start the sprint
        }

        public void FinishSprint()
        {
            // End the sprint
        }
    }
}
