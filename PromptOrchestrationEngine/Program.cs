using System.Text.RegularExpressions;
using PromptOrchestrationEngine.Domain.Logging;
using PromptOrchestrationEngine.Domain.Orchestration;
using PromptOrchestrationEngine.Domain.Pipeline;
using PromptOrchestrationEngine.Domain.Steps;

Console.WriteLine("=== AI Prompt Orchestration Engine ===\n");

var tracer = new ConsoleWorkflowTracer();
var orchestrator = new WorkflowOrchestrator(tracer);

Console.WriteLine("1) Linear pipeline\n");
var linear = new List<IWorkflowStep>
{
    new PromptTransformWorkflowStep(new GenerateStep()),
    new PromptTransformWorkflowStep(new SummarizeStep()),
    new PromptTransformWorkflowStep(new TranslateStep())
};
var linearResult = orchestrator.Run(linear, "product copy");
Console.WriteLine($"   Result: {linearResult.FinalContent}\n");

Console.WriteLine("2) Conditional\n");
var conditional = new List<IWorkflowStep>
{
    new PromptTransformWorkflowStep(new GenerateStep()),
    new ConditionalWorkflowStep(
        "TranslateIfEn",
        ctx => Regex.IsMatch(ctx.Content, @"\bEN\b", RegexOptions.IgnoreCase),
        new PromptTransformWorkflowStep(new TranslateStep()))
};
var conditionalHit = orchestrator.Run(conditional, "EN draft about shoes");
var conditionalSkip = orchestrator.Run(conditional, "draft about shoes");
Console.WriteLine($"   With EN: {conditionalHit.FinalContent}");
Console.WriteLine($"   Without EN: {conditionalSkip.FinalContent}\n");

Console.WriteLine("3) Fallback\n");
var fallback = new List<IWorkflowStep>
{
    new FallbackWorkflowStep(
        "GenerateWithFallback",
        new PromptTransformWorkflowStep(new AlwaysFailsTransformStep()),
        new PromptTransformWorkflowStep(new GenerateStep()))
};
var fallbackResult = orchestrator.Run(fallback, "brief");
Console.WriteLine($"   Result: {fallbackResult.FinalContent}\n");

Console.WriteLine("4) Retry\n");
var retry = new List<IWorkflowStep>
{
    new RetryableWorkflowStep(
        "FlakyWithRetry",
        new PromptTransformWorkflowStep(new FailsUntilTransformStep("FLAKY", failuresBeforeSuccess: 2, successPrefix: "Stable: ")),
        maxAttempts: 5)
};
var retryResult = orchestrator.Run(retry, "input");
Console.WriteLine($"   Result: {retryResult.FinalContent}\n");

Console.WriteLine("=== Demo Complete ===");
