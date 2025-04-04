using DevOps.Pipeline;

namespace Pipeline
{
    public class Pipeline : IPipeline
    {
        public void Start()
        {
            Pipeline pipeline = new Pipeline();
            Console.WriteLine("Starting pipeline tasks");
            pipeline.SetState(new DownloadingSourcesState());            
        }

        public void SetState(IPipelineState state)
        {
            state.Execute(this);
        }
    }
}
