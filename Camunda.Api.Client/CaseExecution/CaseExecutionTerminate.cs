﻿using System.Collections.Generic;

namespace Camunda.Api.Client.CaseExecution;

public class CaseExecutionTerminate
{
  public Dictionary<string, VariableValue> Variables = [];

  // TODO: deletions
}