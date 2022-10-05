using System;
using Lithium.BuildingBlocks.EventBus.Abstractions;
using Lithium.BuildingBlocks.IntegrationEventLogEF.Services;
using System.Data.Common;
using Lithium.DataService;
using Microsoft.Extensions.Logging;
using Lithium.BuildingBlocks.EventBus.Events;

namespace Lithium.IntegrationService;

public class AppStagingApiIntegrationEventService<TContext> : IAppStagingApiIntegrationEventService<TContext> where TContext : BaseAppStagingDbContext
{
    private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
    private readonly IEventBus _eventBus;
    private readonly TContext _dbContext;
    private readonly IIntegrationEventLogService _eventLogService;
    private readonly ILogger<AppStagingApiIntegrationEventService<TContext>> _logger;

    public AppStagingApiIntegrationEventService(Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory, IEventBus eventBus, TContext dbContext, IIntegrationEventLogService eventLogService, ILogger<AppStagingApiIntegrationEventService<TContext>> logger)
    {
        _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task AddAndSaveEventAsync(IntegrationEvent evt)
    {
        _logger.LogInformation("----- Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", evt.Id, evt);

        await _eventLogService.SaveEventAsync(evt, _dbContext.GetCurrentTransaction());
    }

    public async Task PublishEventsThroughEventBusAsync(Guid transactionId, string appName)
    {
        var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);

        foreach (var logEvt in pendingLogEvents)
        {
            _logger.LogInformation("----- Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", logEvt.EventId, appName, logEvt.IntegrationEvent);

            try
            {
                await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                _eventBus.Publish(logEvt.IntegrationEvent);
                await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR publishing integration event: {IntegrationEventId} from {AppName}", logEvt.EventId, appName);

                await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
            }
        }
    }
}

