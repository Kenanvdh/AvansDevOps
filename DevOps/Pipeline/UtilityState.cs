using Pipeline;

namespace DevOps.Pipeline
{
    public class UtilityState : IPipelineState
    {
        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Running utility tasks...");
            pipeline.SetState(new AnalyseState());
        }
    }
}
