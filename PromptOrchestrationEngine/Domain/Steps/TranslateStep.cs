using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Steps;

public sealed class TranslateStep : IPromptTransformStep
{
    public string Name => "TRANSLATE";

    public StepOutcome Transform(StepContext context)
        => new StepOutcome.Succeeded("Translated: " + context.Content);
}
