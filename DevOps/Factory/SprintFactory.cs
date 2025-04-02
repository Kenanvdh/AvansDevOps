namespace DevOps.Factory
{
    public class SprintFactory : IWorkItem
    {
        public void Create(string name, DateOnly startDate, DateOnly endDate)
        {
            Sprints.Sprint sprint = new Sprints.Sprint();
            sprint.Name = name;
            sprint.StartDate = startDate;
            sprint.EndDate = endDate;
        }
    }
}
