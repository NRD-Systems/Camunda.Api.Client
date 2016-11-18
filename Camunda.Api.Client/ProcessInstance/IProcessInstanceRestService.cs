﻿using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Camunda.Api.Client.ProcessInstance
{
    internal interface IProcessInstanceRestService
    {
        [Get("/process-instance/{processInstanceId}")]
        Task<ProcessInstanceInfo> Get(string processInstanceId);

        [Post("/process-instance")]
        Task<List<ProcessInstanceInfo>> GetList([Body] ProcessInstanceQuery query, int? firstResult, int? maxResults);

        [Post("/process-instance/count")]
        Task<CountResult> GetListCount([Body] ProcessInstanceQuery query);

        [Get("/process-instance/{processInstanceId}/activity-instances")]
        Task<ActivityInstanceInfo> GetActivityInstanceTree(string processInstanceId);

        [Delete("/process-instance/{processInstanceId}")]
        Task DeleteProcessInstance(string processInstanceId);

        [Put("/process-instance/suspended"), UniqueName("UpdateSuspensionState")]
        Task UpdateSuspensionState([Body] ProcessInstanceSuspensionState state);

        [Put("/process-instance/{processInstanceId}/suspended"), UniqueName("UpdateSuspensionStateForId")]
        Task UpdateSuspensionState(string processInstanceId, [Body] SuspensionState state);

        [Post("/process-instance/{processInstanceId}/modification")]
        Task ModifyProcessInstance(string processInstanceId, [Body] ProcessInstanceModification modification);

        #region Variables

        [Delete("/process-instance/{id}/variables/{varName}")]
        Task DeleteVariable(string id, string varName);

        [Get("/process-instance/{id}/variables/{varName}")]
        Task<VariableValue> GetVariable(string id, string varName, bool deserializeValue = true);

        [Get("/process-instance/{id}/variables")]
        Task<Dictionary<string, VariableValue>> GetVariables(string id, bool deserializeValues = true);

        [Get("/process-instance/{id}/variables/{varName}/data")]
        Task<HttpResponseMessage> GetBinaryVariable(string id, string varName);

        [Post("/process-instance/{id}/variables/{varName}/data"), Multipart]
        Task SetBinaryVariable(string id, string varName, BinaryDataContent data, ValueTypeContent valueType);

        [Post("/process-instance/{id}/variables")]
        Task ModifyVariables(string id, PatchVariables patch);

        [Put("/process-instance/{id}/variables/{varName}")]
        Task PutVariable(string id, string varName, [Body] VariableValue variable);

        #endregion

    }
}
