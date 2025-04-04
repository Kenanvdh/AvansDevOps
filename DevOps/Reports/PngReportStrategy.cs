using DevOps.Sprints;

namespace Report
{
    public class PngReportStrategy : IReportStrategy
    {
        public void GenerateReport(Sprint sprint)
        {
            Console.WriteLine("Generated PNG-report for sprint " + sprint.Name);
        }
    }
}
