using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Steps;

public sealed class GenerateStep : IPromptTransformStep
{
    public string Name => "GENERATE";

    public StepOutcome Transform(StepContext context)
        => new StepOutcome.Succeeded("Generated: " + context.Content);
}
