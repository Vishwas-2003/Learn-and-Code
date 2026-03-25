using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Steps;

public interface IPromptTransformStep
{
    string Name { get; }

    StepOutcome Transform(StepContext context);
}
