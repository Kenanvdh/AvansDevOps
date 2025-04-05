using Report;

namespace DevOps.Persons
{
    public class ScrumMaster : User
    {
        public static void CloseSprint(Sprints.Sprint sprint)
        {
            sprint.State = Sprints.SprintState.Finished;

            Console.WriteLine("Sprint is finished.");
        }

        public static void GeneratePdfReport(Sprints.Sprint sprint)
        {
            ReportGenerator generator = new ReportGenerator();
            generator.SetStrategy(new PdfReportStrategy());
            generator.GenerateReport(sprint);
        }

        public static void GeneratePngReport(Sprints.Sprint sprint)
        {
            ReportGenerator generator = new ReportGenerator();
            generator.SetStrategy(new PngReportStrategy());
            generator.GenerateReport(sprint);
        }
    }
}
