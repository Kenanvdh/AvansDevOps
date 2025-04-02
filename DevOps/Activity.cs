using AvansDevOps.Domain;

namespace DevOps
{
    public class Activity
    {
        private string Name { get; set; }
        private string Description { get; set; }
        public User Assignee { get; set; }
        private bool Completed { get; set; }

        public void CreateActivity(string name, string description, User assignee)
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
