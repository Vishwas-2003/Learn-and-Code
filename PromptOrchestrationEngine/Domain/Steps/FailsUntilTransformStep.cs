using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Steps;

public sealed class FailsUntilTransformStep : IPromptTransformStep
{
    private int _failuresRemaining;

    public FailsUntilTransformStep(string name, int failuresBeforeSuccess, string successPrefix)
    {
        Name = name;
        _failuresRemaining = failuresBeforeSuccess < 0 ? 0 : failuresBeforeSuccess;
        SuccessPrefix = successPrefix;
    }

    public string Name { get; }
    public string SuccessPrefix { get; }

    public StepOutcome Transform(StepContext context)
    {
        if (_failuresRemaining > 0)
        {
            _failuresRemaining--;
            return new StepOutcome.Failed("Transient step failure.", context.Content);
        }

        return new StepOutcome.Succeeded(SuccessPrefix + context.Content);
    }
}
