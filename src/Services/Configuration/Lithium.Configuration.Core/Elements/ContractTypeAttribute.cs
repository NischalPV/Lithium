using System;
using System.ComponentModel.DataAnnotations.Schema;
using Lithium.BaseEntities;

namespace Lithium.Configuration.Core.Elements
{
	/// <summary>
    /// Contract type attribute model
    /// </summary>
	public record ContractTypeAttribute: BaseEntity<string>
	{
		new public string Name { get; set; }

		[ForeignKey(name: nameof(Attribute))]
		public string AttributeId { get; set; }

		[ForeignKey(name: nameof(ContractType))]
		public string ContractTypeId { get; set; }

		public string InstanceId { get; set; }

		public Attribute Attribute { get; set; }
		public ContractType ContractType { get; set; }

        public ContractTypeAttribute()
        {
			InstanceId = ContractType.InstanceId;
        }
    }
}

