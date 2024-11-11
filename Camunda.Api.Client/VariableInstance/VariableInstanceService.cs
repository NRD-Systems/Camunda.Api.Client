﻿namespace Camunda.Api.Client.VariableInstance;

public class VariableInstanceService
{
  private readonly IVariableInstanceRestService _api;

  internal VariableInstanceService(IVariableInstanceRestService api) => _api = api;

  /// <param name="variableInstanceId">The id of the variable instance.</param>
  public VariableInstanceResource this[string variableInstanceId] 
    => new(_api, variableInstanceId);

  public VariableInstanceQueryResource Query(VariableInstanceQuery query = null)
    => new(_api, query ?? new());
}