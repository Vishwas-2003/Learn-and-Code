using PromptOrchestrationEngine.Domain.Entities;

namespace PromptOrchestrationEngine.Domain.Pipeline;

public interface IWorkflowStep
{
    string Name { get; }

    StepOutcome Execute(StepContext context);
}
