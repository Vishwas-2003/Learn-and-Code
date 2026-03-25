using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Logging;

public interface IWorkflowTracer
{
    void OnWorkflowStarted(string workflowRunId, string initialContent);

    void OnStepStarted(string stepName, int stepIndex, string contentIn);

    void OnStepCompleted(string stepName, int stepIndex, StepOutcome outcome);

    void OnWorkflowCompleted(string workflowRunId, WorkflowRunResult result);
}
