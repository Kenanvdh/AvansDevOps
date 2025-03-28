namespace DevOps
{
    public class Backlog
    {
        private List<BacklogItem> BacklogItems { get; set; }

        public void AddItem(BacklogItem item)
        {
            if(BacklogItems.Contains(item))
            {
                Console.WriteLine("Item already exists in the backlog.");
                return;
            }
            BacklogItems.Add(item);
        }
    }
}
