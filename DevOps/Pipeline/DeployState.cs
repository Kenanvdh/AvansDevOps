using Pipeline;

namespace DevOps.Pipeline
{
    public class DeployState : IPipelineState
    {
        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Deploying solution...");
            pipeline.SetState(new UtilityState());
        }
    }
}
