using System;
namespace Lithium.Configuration.Core.Elements
{
	/// <summary>
    /// Defines the feature of any contract type
    /// </summary>
	public class Feature
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public bool IsActive { get; set; } = true;
		public string Prefix { get; set; }
		public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

		public Feature()
		{
		}
	}
}

