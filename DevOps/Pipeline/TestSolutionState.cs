using DevOps.Pipeline;

namespace Pipeline
{
    public class TestSolutionState : IPipelineState
    {
        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Testing solution...");
            pipeline.SetState(new AnalyseState());
        }
    }
}
