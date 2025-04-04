using Pipeline;

namespace DevOps.Pipeline
{
    public class AnalyseState : IPipelineState
    {
        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Analysing solution...");
            pipeline.SetState(new DeployState());
        }
    }
}
