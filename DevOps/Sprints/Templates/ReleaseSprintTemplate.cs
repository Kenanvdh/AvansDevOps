using DevOps.Persons;
using Pipe = Pipeline.Pipeline;


namespace DevOps.Sprint.Templates
{
    public class ReleaseSprintTemplate : SprintTypeTemplate
    {
        public ReleaseSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void Execute(User user)
        {
            Console.WriteLine($"Starting release process for sprint '{Sprint.Name}'...");

            var pipeline = new Pipe();
            pipeline.Start(Sprint);
        }
    }
}
