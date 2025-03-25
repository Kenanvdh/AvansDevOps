namespace DevOps
{
    public class Project
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private List<Sprint> Sprints { get; set; }
        private Backlog Backlog { get; set; }

        public void CreateSprint(string name, DateOnly startDate, DateOnly endDate)
        {
            Sprints.Add(new Sprint(name, startDate, endDate));
        }
    }
}
