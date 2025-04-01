using DevOps.BacklogItems;
using DevOps.Sprint.State;

namespace DevOps.Sprint
{
    public class Sprint
    {
        public string Name { get; set; }
        private DateOnly StartDate { get; set; }
        private DateOnly EndDate { get; set; }
        private List<BacklogItem> BacklogItems { get; set; }
        private SprintState State { get; set; }

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
