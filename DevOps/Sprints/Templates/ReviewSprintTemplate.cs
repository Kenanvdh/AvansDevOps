using DevOps.Sprints;
using DevOps.BacklogItems;
using DevOps.Persons;

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

        protected override void Deploy(User user)
        {
            Console.WriteLine("Trying to finalize the Review Sprint...");

            if (!Sprint.IsScrumMaster(user))
            {
                Console.WriteLine("Alleen de Scrum Master mag de sprint afsluiten.");
                return;
            }

            if (Sprint.State != SprintState.Reviewed)
            {
                Console.WriteLine("Sprint kan niet worden afgesloten. Status is niet 'Reviewed'.");
                return;
            }

            if (string.IsNullOrEmpty(Sprint.ReviewSummaryDocumentPath))
            {
                Console.WriteLine("Sprint kan niet worden afgesloten. Reviewdocument ontbreekt.");
                return;
            }

            Sprint.UpdateSprintState(Sprint.Name, SprintState.Finished);
            Console.WriteLine("Sprint succesvol afgesloten na review met upload.");
        }

    }
}
