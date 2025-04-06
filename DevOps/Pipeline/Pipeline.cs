using DevOps.Sprints;
using Pipeline;

namespace DevOps.Pipeline
{
    public class Pipeline : IPipeline
    {
        public void Start(Sprints.Sprint sprint)
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
