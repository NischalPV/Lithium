using System;
using Lithium.Configuration.Core.AppStaging;
using MediatR;

namespace Lithium.Configuration.Core.Events.AppStaging;

public class AppStagingContractTypeCreatedEvent: INotification
{
    public AppStagingContractType ContractType { get; }

    public AppStagingContractTypeCreatedEvent(AppStagingContractType contractType)
    {
        ContractType = contractType;
    }
}

