using Pipeline;

namespace DevOps.Pipeline
{
    public interface IPipelineState
    {
        void Execute(IPipeline pipeline);

    }
}
