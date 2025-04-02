namespace DevOps
{
    public class Activity
    {
        public string Name { get; set; }
        private string Description { get; set; }
        public Persons.User Assignee { get; set; }
        private bool Completed { get; set; }

        public void CreateActivity(string name, string description, Persons.User assignee)
        {
            Name = name;
            Description = description;
            Assignee = assignee;
            Completed = false;
        }

        public bool MarkCompleted()
        {            
            return Completed;
        }
    }
}
