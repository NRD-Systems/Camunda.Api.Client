﻿using System.Collections.Generic;

namespace Camunda.Api.Client.CaseExecution;

public class CaseExecutionStart
{
  public Dictionary<string, VariableValue> Variables = [];

  // TODO: deletions
}