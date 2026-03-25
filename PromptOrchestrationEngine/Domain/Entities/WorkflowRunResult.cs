namespace PromptOrchestrationEngine.Domain.Entities;

public sealed record WorkflowRunResult(bool Succeeded, string FinalContent, string? FailureMessage);
