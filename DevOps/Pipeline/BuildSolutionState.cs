using Pipeline;

namespace DevOps.Pipeline
{
    public class BuildSolutionState : IPipelineState
    {
        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Building solution...");
            pipeline.SetState(new TestSolutionState());
        }
    }
}
