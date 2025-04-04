using DevOps.Pipeline;

namespace Pipeline
{
    public interface IPipeline
    {
        void Start();
        void SetState(IPipelineState state);
    }
}
