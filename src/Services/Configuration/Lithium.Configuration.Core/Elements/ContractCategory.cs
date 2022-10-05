using System;
namespace Lithium.Configuration.Core.Elements
{
	public record ContractCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; } = true;
	}
}

