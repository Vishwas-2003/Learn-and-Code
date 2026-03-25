using PromptOrchestrationEngine.Domain.Entities;
using PromptOrchestrationEngine.Domain.Steps;

namespace PromptOrchestrationEngine.Domain.Pipeline;

public sealed class PromptTransformWorkflowStep : IWorkflowStep
{
    private readonly IPromptTransformStep _inner;

    public PromptTransformWorkflowStep(IPromptTransformStep inner)
    {
        _inner = inner;
    }

    public string Name => _inner.Name;

    public StepOutcome Execute(StepContext context)
        => _inner.Transform(context);
}
