using DevOps.Sprints;

namespace Report
{
    public interface IReportStrategy
    {
        void GenerateReport(Sprint sprint);
    }
}
