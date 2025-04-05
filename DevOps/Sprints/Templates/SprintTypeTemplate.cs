using DevOps.Persons;

namespace DevOps.Sprint.Templates
{
    public abstract class SprintTypeTemplate
    {
        protected Sprints.Sprint Sprint;

        protected SprintTypeTemplate(Sprints.Sprint sprint)
        {
            this.Sprint = sprint;
        }

        public void RunSprint(User user)
        {
            if (!Sprint.IsScrumMaster(user))
            {
                Console.WriteLine($"Access denied. User '{user.Name}' is not the Scrum Master of sprint '{Sprint.Name}'.");
                return;
            }

            Execute(user);
        }
        protected abstract void Execute(User user);
    }
}
