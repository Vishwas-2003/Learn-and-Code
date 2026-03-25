using PromptOrchestrationEngine.Domain.Entities;
using PromptOrchestrationEngine.Domain.Logging;
using PromptOrchestrationEngine.Domain.Pipeline;

namespace PromptOrchestrationEngine.Domain.Orchestration;

public sealed class WorkflowOrchestrator
{
    private readonly IWorkflowTracer _tracer;

    public WorkflowOrchestrator(IWorkflowTracer tracer)
    {
        _tracer = tracer;
    }

    public WorkflowRunResult Run(IReadOnlyList<IWorkflowStep> steps, string initialInput)
    {
        var runId = Guid.NewGuid().ToString("N")[..12];
        var context = new StepContext(initialInput, runId);

        _tracer.OnWorkflowStarted(runId, initialInput);

        var stepIndex = 0;
        foreach (var step in steps)
        {
            stepIndex++;

            _tracer.OnStepStarted(step.Name, stepIndex, context.Content);

            var outcome = step.Execute(context);

            _tracer.OnStepCompleted(step.Name, stepIndex, outcome);

            if (outcome is StepOutcome.Failed failed)
            {
                var result = new WorkflowRunResult(false, failed.ContentAtFailure, failed.Message);
                _tracer.OnWorkflowCompleted(runId, result);
                return result;
            }

            if (outcome is StepOutcome.Succeeded ok)
                context = context.WithContent(ok.Content);
        }

        var success = new WorkflowRunResult(true, context.Content, null);
        _tracer.OnWorkflowCompleted(runId, success);
        return success;
    }
}
