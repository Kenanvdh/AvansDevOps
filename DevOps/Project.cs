
using DevOps.Factory;
using DevOps.Persons;

namespace DevOps
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Version { get; set; }
        public List<Sprints.Sprint> Sprints { get; set; }
        public Backlog Backlog { get; set; }
        public User ProductOwner { get; set; }
        public List<User> Testers { get; set; }

        public ProjectFactory ProjectFactory;
        public SprintFactory SprintFactory;

        public Project() { }

        public Project(ProjectFactory projectFactory, SprintFactory sprintFactory)
        {
            ProjectFactory = projectFactory;
            SprintFactory = sprintFactory;
        }

        public void CreateProject(string name, DateOnly startDate, DateOnly endDate, User productOwner)
        {
            Project project = ProjectFactory.Create(name, startDate, endDate);
            project.ProductOwner = productOwner;
            Console.WriteLine($"Project {name} created.");
        }

        public void AddSprint(string projectName, string sprintName, DateOnly startDate, DateOnly endDate, User sprintMaster)
        {
            if (Name != projectName)
            {
                Console.WriteLine($"Project {projectName} not found.");
                return;
            }

            var sprint = SprintFactory.Create(sprintName, startDate, endDate);
            sprint.SprintMaster = sprintMaster;
            Sprints.Add(sprint);
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
