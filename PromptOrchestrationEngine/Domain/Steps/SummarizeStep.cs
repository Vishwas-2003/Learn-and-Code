using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Steps;

public sealed class SummarizeStep : IPromptTransformStep
{
    public string Name => "SUMMARIZE";

    public StepOutcome Transform(StepContext context)
        => new StepOutcome.Succeeded("Summary of: " + context.Content);
}
