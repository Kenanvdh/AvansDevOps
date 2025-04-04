using DevOps.Sprints;
using DevOps.BacklogItems;

namespace DevOps.Sprint.Templates
{
    public class ReviewSprintTemplate : SprintTypeTemplate
    {
        public ReviewSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void PlanSprint()
        {
            Console.WriteLine("Planning Review Sprint...");
            Sprint.UpdateSprintState(Sprint.Name, SprintState.Planned);
        }

        protected override void Develop()
        {
            Console.WriteLine("Starting development in Review Sprint...");
            foreach (var item in Sprint.BacklogItems)
            {
                item.ChangeState(BacklogItemState.Doing);
            }
        }

        protected override void Test()
        {
            Console.WriteLine("Testing items in Review Sprint...");
            foreach (var item in Sprint.BacklogItems)
            {
                item.ChangeState(BacklogItemState.ReadyForTesting);
            }
        }

        protected override void Review()
        {
            Console.WriteLine("Reviewing items in Review Sprint...");
            foreach (var item in Sprint.BacklogItems)
            {
                item.ChangeState(BacklogItemState.Done);
            }
            Sprint.UpdateSprintState(Sprint.Name, SprintState.Reviewed);
        }

        protected override void Deploy()
        {
            Console.WriteLine("No deployment needed for Review Sprint.");
        }
    }
}
