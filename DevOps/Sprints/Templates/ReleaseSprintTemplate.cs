using DevOps.Sprints;
using DevOps.BacklogItems;

namespace DevOps.Sprint.Templates
{
    public class ReleaseSprintTemplate : SprintTypeTemplate
    {
        public ReleaseSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void PlanSprint()
        {
            Console.WriteLine("Planning Release Sprint...");
            Sprint.UpdateSprintState(Sprint.Name, SprintState.Planned);
        }

        protected override void Develop()
        {
            Console.WriteLine("Finalizing development for Release Sprint...");
            foreach (var item in Sprint.BacklogItems)
            {
                item.ChangeState(BacklogItemState.Doing);
                item.ChangeState(BacklogItemState.Done);
            }
        }

        protected override void Test()
        {
            Console.WriteLine("Running final tests...");
        }

        protected override void Review()
        {
            Console.WriteLine("Final review and documentation...");
        }

        protected override void Deploy()
        {
            Console.WriteLine("Deploying release items...");
            foreach (var item in Sprint.BacklogItems)
            {
                item.FinishItem();
            }
            Sprint.UpdateSprintState(Sprint.Name, SprintState.Finished);
        }
    }
}
