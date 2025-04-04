using DevOps.Persons;

namespace DevOps.Sprint.Templates
{
    public abstract class SprintTypeTemplate
    {
        protected Sprints.Sprint Sprint;

        public SprintTypeTemplate(Sprints.Sprint sprint)
        {
            this.Sprint = sprint;
        }

        public void RunSprint(User user)
        {
            PlanSprint();
            Develop();
            Test();
            Review();
            Deploy(user);
        }

        protected abstract void PlanSprint();
        protected abstract void Develop();
        protected abstract void Test();
        protected abstract void Review();
        protected abstract void Deploy(User user);
    }
}
