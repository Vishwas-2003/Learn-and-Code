using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Pipeline;

public sealed class FallbackWorkflowStep : IWorkflowStep
{
    private readonly IWorkflowStep _primary;
    private readonly IWorkflowStep _fallback;

    public FallbackWorkflowStep(string name, IWorkflowStep primary, IWorkflowStep fallback)
    {
        Name = name;
        _primary = primary;
        _fallback = fallback;
    }

    public string Name { get; }

    public StepOutcome Execute(StepContext context)
    {
        var primaryResult = _primary.Execute(context);
        if (primaryResult is StepOutcome.Succeeded ok)
            return ok;

        return _fallback.Execute(context);
    }
}
