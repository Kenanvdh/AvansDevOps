namespace DevOps
{
    public class Backlog
    {
        private List<BacklogItem> BacklogItems { get; set; }

        public void AddItem(BacklogItem item)
        {
            BacklogItems.Add(item);
        }
    }
}
