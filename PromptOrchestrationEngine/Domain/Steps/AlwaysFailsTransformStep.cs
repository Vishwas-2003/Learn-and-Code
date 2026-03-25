using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Steps;

public sealed class AlwaysFailsTransformStep : IPromptTransformStep
{
    public string Name => "UNAVAILABLE";

    public StepOutcome Transform(StepContext context)
        => new StepOutcome.Failed("Primary model unavailable.", context.Content);
}
