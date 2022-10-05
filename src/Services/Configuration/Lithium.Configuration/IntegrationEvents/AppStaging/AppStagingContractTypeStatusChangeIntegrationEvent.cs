using System;
using Lithium.BuildingBlocks.EventBus.Events;

namespace Lithium.Configuration.IntegrationEvents.AppStaging
{
    public record AppStagingContractTypeStatusChangeIntegrationEvent: IntegrationEvent
    {
        public string ContractType { get; }
        public string Status { get; }
        public string EntityId { get; }

        public AppStagingContractTypeStatusChangeIntegrationEvent(string contractType, string status, string entityId)
        {
            ContractType = contractType;
            Status = status;
            EntityId = entityId;
        }
    }
}

