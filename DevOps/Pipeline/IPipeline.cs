using DevOps.Pipeline;
using DevOps.Sprints;

namespace Pipeline
{
    public interface IPipeline
    {
        void Start(Sprint sprint);
        void SetState(IPipelineState state);
    }
}
