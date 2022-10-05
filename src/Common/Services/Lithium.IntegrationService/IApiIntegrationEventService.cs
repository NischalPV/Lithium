using Lithium.BuildingBlocks.EventBus.Events;
using Lithium.DataService;

namespace Lithium.IntegrationService
{
    public interface IApiIntegrationEventService<TContext> where TContext : BaseDbContext
    {
        Task AddAndSaveEventAsync(IntegrationEvent evt);
        Task PublishEventsThroughEventBusAsync(Guid transactionId, string appName);
    }
}