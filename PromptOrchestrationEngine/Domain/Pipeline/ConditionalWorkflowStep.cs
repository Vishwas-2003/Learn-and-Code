using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Pipeline;

public delegate bool StepPredicate(StepContext context);

public sealed class ConditionalWorkflowStep : IWorkflowStep
{
    private readonly StepPredicate _shouldRun;
    private readonly IWorkflowStep _inner;

    public ConditionalWorkflowStep(string name, StepPredicate shouldRun, IWorkflowStep inner)
    {
        Name = name;
        _shouldRun = shouldRun;
        _inner = inner;
    }

    public string Name { get; }

    public StepOutcome Execute(StepContext context)
    {
        if (!_shouldRun(context))
            return new StepOutcome.Succeeded(context.Content);

        return _inner.Execute(context);
    }
}
