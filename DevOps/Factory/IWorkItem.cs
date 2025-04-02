namespace DevOps.Factory
{
    public interface IWorkItem<T>
    {
         T Create(string name, DateOnly startDate, DateOnly endDate);
    }
}
