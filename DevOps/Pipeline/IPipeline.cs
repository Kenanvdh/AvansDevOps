using DevOps.Pipeline;

namespace Pipeline
{
    public interface IPipeline
    {
        void Start();
        void Stop();
        void SetState(IPipelineState state);
    }
}
