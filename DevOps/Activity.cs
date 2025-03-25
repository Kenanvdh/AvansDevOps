namespace DevOps
{
    public class Activity
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private bool Completed { get; set; }

        public bool MarkCompleted()
        {            
            return Completed;
        }
    }
}
