using DevOps.Pipeline;

namespace Pipeline
{
    public class InstallPackagesState : IPipelineState
    {
        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Installing packages...");
            pipeline.SetState(new BuildSolutionState());
        }
    }
}
