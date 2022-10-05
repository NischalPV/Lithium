
using Lithium.BaseEntities;

namespace Lithium.Configuration.Core.AppStaging;

public record AppStagingContractType : BaseAppStaging<string>
{
    public string EntityId { get; set; }
    public string CategoryId { get; set; }
    public string Feature { get; set; }
}

