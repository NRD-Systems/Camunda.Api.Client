﻿using System.Threading.Tasks;

namespace Camunda.Api.Client.Execution;

public class ExecutionResource
{
  private readonly IExecutionRestService _api;
  private readonly string _executionId;

  internal ExecutionResource(IExecutionRestService api, string executionId)
  {
    _api = api;
    _executionId = executionId;
  }

  public LocalVariableResource LocalVariables => new(_api, _executionId);

  /// <summary>
  /// Retrieves a single execution according to the Execution interface in the engine.
  /// </summary>
  public Task<ExecutionInfo> Get() => _api.Get(_executionId);
  /// <summary>
  /// Signals a single execution. Can for example be used to explicitly skip user tasks or signal asynchronous continuations.
  /// </summary>
  public Task Trigger(ExecutionTrigger trigger) 
    => _api.TriggerExecution(_executionId, trigger);

  public EventSubscriptionResource GetMessageEventSubscription(string messageName) 
    => new(_api, _executionId, messageName);

  public override string ToString() => _executionId;
}