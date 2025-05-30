﻿using DevOps.BacklogItems;

namespace DevOps
{
    public class Backlog
    {
        public List<BacklogItem> BacklogItems { get; } = new List<BacklogItem>();

        public void AddItem(BacklogItem item)
        {
            if (BacklogItems.Contains(item))
            {
                Console.WriteLine("Item already exists in the backlog.");
                return;
            }
            BacklogItems.Add(item);
        }
    }
}
