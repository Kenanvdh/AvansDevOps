﻿using DevOps.Sprints;

namespace Report
{
    public class ReportGenerator
    {
        public IReportStrategy? ReportStrategy { get; set; }

        public void SetStrategy(IReportStrategy reportStrategy)
        {
            this.ReportStrategy = reportStrategy;
        }

        public void GenerateReport(Sprint sprint)
        {
            ReportStrategy?.GenerateReport(sprint);
        }
    }
}  
