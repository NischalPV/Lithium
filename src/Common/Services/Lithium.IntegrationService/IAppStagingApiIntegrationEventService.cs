using System;
using Lithium.BuildingBlocks.EventBus.Events;
using Lithium.DataService;

namespace Lithium.IntegrationService;

public interface IAppStagingApiIntegrationEventService<TContext> where TContext : BaseAppStagingDbContext
{
    Task AddAndSaveEventAsync(IntegrationEvent evt);
    Task PublishEventsThroughEventBusAsync(Guid transactionId, string appName);
}

