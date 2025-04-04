using DevOps.Pipeline;
using DevOps.Sprints;

namespace Pipeline
{
    public class Pipeline : IPipeline
    {
public void Start(Sprint sprint)
{
    Console.WriteLine("Starting pipeline tasks");
    SetState(new DownloadingSourcesState());            
}

        public void SetState(IPipelineState state)
        {
            state.Execute(this);
        }
    }
}
