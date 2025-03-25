namespace DevOps
{
    public class BacklogItem
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private List<Activity> Activities { get; set; }

        public void ChangeState(BacklogItemState state)
        {
            // Change the state of the backlog item
        }
    }
}
