using DevOps.Sprint;

namespace Report
{
    public class PdfReportStrategy : IReportStrategy
    {
        public void GenerateReport(Sprint sprint)
        {
            Console.WriteLine("Generated PDF-report for sprint " + sprint.Name);
        }
    }
}
