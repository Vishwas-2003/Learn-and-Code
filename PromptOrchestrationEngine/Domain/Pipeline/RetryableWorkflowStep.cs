using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Pipeline;

public sealed class RetryableWorkflowStep : IWorkflowStep
{
    private readonly IWorkflowStep _inner;

    public RetryableWorkflowStep(string name, IWorkflowStep inner, int maxAttempts)
    {
        Name = name;
        _inner = inner;
        MaxAttempts = maxAttempts < 1 ? 1 : maxAttempts;
    }

    public string Name { get; }
    public int MaxAttempts { get; }

    public StepOutcome Execute(StepContext context)
    {
        StepOutcome last = new StepOutcome.Failed("No attempts made.", context.Content);

        foreach (var _ in Enumerable.Range(1, MaxAttempts))
        {
            last = _inner.Execute(context);
            if (last is StepOutcome.Succeeded)
                return last;
        }

        return last;
    }
}
