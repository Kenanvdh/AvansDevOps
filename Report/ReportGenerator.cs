using DevOps;

namespace Report
{
    public class RepostGenerator
    {
        private IReportStrategy ReportStrategy { get; set; }

        public void SetStrategy(IReportStrategy reportStrategy)
        {
            this.ReportStrategy = reportStrategy;
        }

        public void GenerateReport(Sprint sprint)
        {
            ReportStrategy.GenerateReport(sprint);
        }
    }
}  
