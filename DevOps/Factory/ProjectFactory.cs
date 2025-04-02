namespace DevOps.Factory
{
    public class ProjectFactory : IWorkItem<Project>
    {
        public Project Create(string name, DateOnly startDate, DateOnly endDate)
        {
            Project project = new Project();
            project.Name = name;
            project.StartDate = startDate;
            project.EndDate = endDate;
            project.Version = 1;
            return project;
        }
    }
}
