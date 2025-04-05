namespace DevOps.Factory
{
    public interface IWorkItem<out T>
    {
         T Create(string name, DateOnly startDate, DateOnly endDate);
    }
}
