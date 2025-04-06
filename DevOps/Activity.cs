using DevOps.Persons;

namespace DevOps
{
    public class Activity
    {
        private string? Name { get; set; } = string.Empty;
        private string Description { get; set; } = string.Empty;
        public User Assignee { get; set; }
        public bool Completed { get; set; }

        public void CreateActivity(string name, string description, Persons.User assignee)
        {
            Name = name;
            Description = description;
            Assignee = assignee;
            Completed = false;
        }

        public bool MarkCompleted()
        {            
            return Completed = true;
        }
    }
}
