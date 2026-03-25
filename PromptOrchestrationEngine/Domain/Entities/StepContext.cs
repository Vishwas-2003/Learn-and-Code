namespace PromptOrchestrationEngine.Domain.Entities;

public sealed record StepContext(string Content, string WorkflowRunId)
{
    public StepContext WithContent(string newContent)
        => this with { Content = newContent };
}
