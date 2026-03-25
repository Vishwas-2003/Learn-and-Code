using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Logging;

public sealed class ConsoleWorkflowTracer : IWorkflowTracer
{
    public void OnWorkflowStarted(string workflowRunId, string initialContent)
        => Console.WriteLine($"[trace] Workflow {workflowRunId} start | in: {initialContent}");

    public void OnStepStarted(string stepName, int stepIndex, string contentIn)
        => Console.WriteLine($"[trace] Step #{stepIndex} {stepName} | in: {contentIn}");

    public void OnStepCompleted(string stepName, int stepIndex, StepOutcome outcome)
    {
        var detail = outcome switch
        {
            StepOutcome.Succeeded s => $"ok -> {s.Content}",
            StepOutcome.Failed f => $"fail: {f.Message}",
            _ => "unknown"
        };
        Console.WriteLine($"[trace] Step #{stepIndex} {stepName} | {detail}");
    }

    public void OnWorkflowCompleted(string workflowRunId, WorkflowRunResult result)
    {
        var status = result.Succeeded ? "success" : "failed";
        Console.WriteLine($"[trace] Workflow {workflowRunId} {status} | out: {result.FinalContent}");
    }
}
