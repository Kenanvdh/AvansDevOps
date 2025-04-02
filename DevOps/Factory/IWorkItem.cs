namespace DevOps.Factory
{
    public interface IWorkItem
    {
        void Create(string name, DateOnly startDate, DateOnly endDate);
    }
}
