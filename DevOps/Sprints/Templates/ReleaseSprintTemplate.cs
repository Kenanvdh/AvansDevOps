using DevOps.Persons;
using Pipeline;

namespace DevOps.Sprint.Templates
{
    public class ReleaseSprintTemplate : SprintTypeTemplate
    {
        public ReleaseSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void Execute(User user)
        {
            Console.WriteLine($"Starting release process for sprint '{Sprint.Name}'...");

            var pipeline = new Pipeline.Pipeline();
            pipeline.Start(Sprint);
        }
    }
}
