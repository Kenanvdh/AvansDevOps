using DevOps.Persons;

namespace Threads
{
    public class Message : ThreadComponent
    {
        private readonly User createdBy;
        private readonly List<ThreadComponent> replies = new List<ThreadComponent>(); // Reacties op berichten

        public Message(string content, User user) : base(content)
        {
            this.createdBy = user;
        }

        public override void Add(ThreadComponent component)
        {
            replies.Add(component);
        }

        public override void Remove(ThreadComponent component)
        {
            replies.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + $" Message by {createdBy.Name}: {content} ({timestamp})");
            foreach (var reply in replies)
            {
                reply.Display(depth + 2);
            }
        }
    }
}

