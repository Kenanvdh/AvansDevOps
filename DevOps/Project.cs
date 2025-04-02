
using DevOps.Factory;

namespace DevOps
{
    public class Project
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Version { get; set; }
        private List<Sprints.Sprint> Sprints { get; set; }
        private Backlog Backlog { get; set; }

        public ProjectFactory ProjectFactory;
        public SprintFactory SprintFactory;

        public Project() { }

        public Project(ProjectFactory projectFactory, SprintFactory sprintFactory)
        {
            ProjectFactory = projectFactory;
            SprintFactory = sprintFactory;
        }

        public void CreateProject(string name, DateOnly startDate, DateOnly endDate)
        {
            ProjectFactory.Create(name, startDate, endDate);
            Console.WriteLine($"Project {name} created.");
        }

        public void AddSprint(string name, DateOnly startDate, DateOnly endDate)
        {
            //Sprint toevoegen aan project
            SprintFactory.Create(name, startDate, endDate);
            Console.WriteLine($"Sprint {name} created.");
        }
    }
}
