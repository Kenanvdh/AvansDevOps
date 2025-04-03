namespace DevOps.Persons
{
    public abstract class User
    {
        public string Name { get; set; }
        private string Role { get; set; }

        public void SendMessage(string name, string message)
        {
            Console.WriteLine($"New message for {name}: {message}");
        }
    }
}
