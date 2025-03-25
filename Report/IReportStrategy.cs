﻿using DevOps;

namespace Report
{
    public interface IReportStrategy
    {
        public void GenerateReport(Sprint sprint);
    }
}
