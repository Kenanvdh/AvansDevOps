namespace DevOps.Factory
{
    public class SprintFactory : IWorkItem<Sprints.Sprint>
    {
        public virtual Sprints.Sprint Create(string name, DateOnly startDate, DateOnly endDate)
        {
            Sprints.Sprint sprint = new Sprints.Sprint();
            sprint.Name = name;
            sprint.StartDate = startDate;
            sprint.EndDate = endDate;
            return sprint;
        }
    }
}
