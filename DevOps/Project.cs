
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

        public void AddSprint(string projectName, string sprintName, DateOnly startDate, DateOnly endDate)
        {
            Sprints.Sprint sprint = SprintFactory.Create(sprintName, startDate, endDate);

            if (Name == projectName)
            {
                Sprints.Add(sprint);
            }
            else
            {
                Console.WriteLine($"Project {projectName} not found.");
            }

            Console.WriteLine($"Sprint {sprintName} created.");
        }

        public void AddBacklog(string projectName, Backlog backlog)
        {
            if (Name == projectName)
            {
                Backlog = backlog;
            }
            else
            {
                Console.WriteLine($"Project {projectName} not found.");
            }
        }
    }
}
