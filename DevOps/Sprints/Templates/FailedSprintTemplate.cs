using DevOps.Sprints;
using DevOps.BacklogItems;
using DevOps.Persons;

namespace DevOps.Sprint.Templates
{
    public class FailedSprintTemplate : SprintTypeTemplate
    {
        public FailedSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void Execute(User user)
        {
            Console.WriteLine($"Sprint '{Sprint.Name}' has failed. No further action will be taken.");
        }
    }
}
