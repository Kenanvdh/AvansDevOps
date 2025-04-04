using DevOps.Sprints;
using DevOps.BacklogItems;
using DevOps.Persons;

namespace DevOps.Sprint.Templates
{
    public class ReviewSprintTemplate : SprintTypeTemplate
    {
        public ReviewSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void Execute(User user)
        {
            Console.WriteLine($"Review Sprint: Planning review for sprint '{Sprint.Name}'...");

            foreach (var item in Sprint.GetItems())
            {
                item.ChangeState(BacklogItemState.Done);
            }

            Console.WriteLine($"All backlog items in sprint '{Sprint.Name}' are marked as Done.");
        }
    }
}
