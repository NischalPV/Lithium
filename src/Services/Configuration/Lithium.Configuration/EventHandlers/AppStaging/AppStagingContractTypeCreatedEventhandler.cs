using System;
using Lithium.BaseEntities;
using Lithium.Configuration.Core.AppStaging;
using Lithium.Configuration.Core.Events.AppStaging;
using Lithium.Configuration.Core.Interfaces.AppStaging;
using Lithium.Configuration.IntegrationEvents.AppStaging;
using Lithium.DataService;
using Lithium.IntegrationService;
using MediatR;

namespace Lithium.Configuration.EventHandlers.AppStaging
{
    public class AppStagingContractTypeCreatedEventhandler: INotificationHandler<AppStagingContractTypeCreatedEvent>
    {
        private readonly IBaseAppStagingAsyncRepository<AppStagingContractType, string> _contractTypeRepository;
        private readonly ILoggerFactory _logger;
        private readonly IAppStagingApiIntegrationEventService<BaseAppStagingDbContext> _contractTypeIntegrationEventService;

        public AppStagingContractTypeCreatedEventhandler(IBaseAppStagingAsyncRepository<AppStagingContractType, string> contractTypeRepository, ILoggerFactory logger, IAppStagingApiIntegrationEventService<BaseAppStagingDbContext> contractTypeIntegrationEventService)
        {
            _contractTypeRepository = contractTypeRepository;
            _logger = logger;
            _contractTypeIntegrationEventService = contractTypeIntegrationEventService;
        }

        public async Task Handle(AppStagingContractTypeCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<AppStagingContractTypeCreatedEvent>()
               .LogTrace("Contract type: {DisplayName} has been successfully created. ({Id})",
                   notification.ContractType.DisplayName, notification.ContractType.Id);

            var ct = await _contractTypeRepository.GetByIdAsync(notification.ContractType.Id);

            var appStagingContractTypeStatusChangeIntegrationEvent = new AppStagingContractTypeStatusChangeIntegrationEvent(notification.ContractType.DisplayName, "Created", notification.ContractType.Id);
            await _contractTypeIntegrationEventService.AddAndSaveEventAsync(appStagingContractTypeStatusChangeIntegrationEvent);
        }
    }
}

