using DevOps.Pipeline;

namespace Pipeline
{
    public class DownloadingSourcesState : IPipelineState
    {

        public void Execute(IPipeline pipeline)
        {
            Console.WriteLine("Downloading sources...");
            pipeline.SetState(new InstallPackagesState());
        }
    }
}
