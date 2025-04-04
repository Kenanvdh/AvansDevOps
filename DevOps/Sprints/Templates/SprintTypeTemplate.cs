namespace DevOps.Sprint.Templates
{
    public abstract class SprintTypeTemplate
    {
        protected Sprints.Sprint Sprint;

        public SprintTypeTemplate(Sprints.Sprint sprint)
        {
            this.Sprint = sprint;
        }

        public void RunSprint()
        {
            PlanSprint();
            Develop();
            Test();
            Review();
            Deploy();
        }

        protected abstract void PlanSprint();
        protected abstract void Develop();
        protected abstract void Test();
        protected abstract void Review();
        protected abstract void Deploy();
    }
}
