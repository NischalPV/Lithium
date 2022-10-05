using System;
namespace Lithium.Configuration.Core.Elements
{
	public record ContractStage
	{
		public int Id { get; set; }
		public string Stage { get; set; }
		public bool IsActive { get; set; }

		public ContractStage()
		{
			IsActive = true;
		}
	}
}

