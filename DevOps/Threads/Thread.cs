namespace Threads
{
    internal class Thread : ThreadComponent
    {
        private List<ThreadComponent> children = new List<ThreadComponent>();
        private User createdBy;
        private bool isClosed = false; // Thread begint open

        public Thread(string content, Persons.User user) : base(content)
        {
            this.createdBy = user;
        }

        public override void Add(ThreadComponent component)
        {
            if (isClosed)
            {
                Console.WriteLine("Cannot add a message. The thread is closed.");
                return;
            }

            children.Add(component);
        }

        public override void Remove(ThreadComponent component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + $" Thread by {createdBy.Name}: {content} ({timestamp}) {(isClosed ? "[CLOSED]" : "")}");
            foreach (var component in children)
            {
                component.Display(depth + 2);
            }
        }

        public void CloseThread()
        {
            isClosed = true;
            Console.WriteLine($"Thread closed by {createdBy.Name}.");
        }

        public void openThread()
        {
            isClosed = false;
            Console.WriteLine($"Thread opened by {createdBy.Name}.");
        }
    }
}
