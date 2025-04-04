using DevOps.Sprints;
using DevOps.BacklogItems;
using DevOps.Persons;

namespace DevOps.Sprint.Templates
{
    public class FailedSprintTemplate : SprintTypeTemplate
    {
        public FailedSprintTemplate(Sprints.Sprint sprint) : base(sprint) { }

        protected override void PlanSprint()
        {
            Console.WriteLine("Failed Sprint: planning retrospect...");
        }

        protected override void Develop()
        {
            Console.WriteLine("Marking all items as not completed...");
            foreach (var item in Sprint.BacklogItems)
            {
                item.ChangeState(BacklogItemState.ToDo);
            }
        }

        protected override void Test()
        {
            Console.WriteLine("No testing performed in failed sprint.");
        }

        protected override void Review()
        {
            Console.WriteLine("Retrospective of the failed sprint.");
        }

        protected override void Deploy(User user)
        {
            if (!Sprint.IsScrumMaster(user))
            {
                Console.WriteLine("Alleen de Scrum Master mag een sprint als gefaald markeren.");
                return;
            }

            if (Sprint.State == SprintState.Finished)
            {
                Console.WriteLine("Sprint is al afgerond. Kan niet opnieuw falen.");
                return;
            }

            Console.WriteLine("No deployment, Sprint has failed.");
            Sprint.UpdateSprintState(Sprint.Name, SprintState.Planned);
        }

    }
}
