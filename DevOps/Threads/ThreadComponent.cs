namespace Threads
{
    public abstract class ThreadComponent
    {
        protected string content;
        protected DateTime timestamp;

        protected ThreadComponent(string content)
        {
            this.content = content;
            this.timestamp = DateTime.Now;
        }

        public abstract void Add(ThreadComponent component);
        public abstract void Remove(ThreadComponent component);
        public abstract void Display(int depth);
    }
}
