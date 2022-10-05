using System.ComponentModel.DataAnnotations.Schema;
using Lithium.BaseEntities;

namespace Lithium.Configuration.Core.AppStaging
{
    public record AppStagingAttribute: BaseAppStaging<string>
    {

        public string AttributeId { get; set; }

        public AppStagingAttribute()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

