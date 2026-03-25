namespace PromptOrchestrationEngine.Domain.Entities;

public abstract record StepOutcome
{
    public sealed record Succeeded(string Content) : StepOutcome;

    public sealed record Failed(string Message, string ContentAtFailure) : StepOutcome;

    public bool IsSuccess => this is Succeeded;
}
