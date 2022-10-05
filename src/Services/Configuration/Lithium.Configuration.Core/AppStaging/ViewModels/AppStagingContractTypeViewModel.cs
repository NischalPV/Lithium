using System;
using Lithium.Configuration.Core.AppStaging;

namespace Lithium.Configuration.Core.AppStaging.ViewModels;

public class AppStagingContractTypeViewModel
{
    public AppStagingContractType ContractType { get; set; }
    public List<AppStagingAttribute> Attributes { get; set; }
}

