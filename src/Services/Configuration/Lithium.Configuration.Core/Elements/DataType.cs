using System;
namespace Lithium.Configuration.Core.Elements
{
	public class DataType
	{

		public int Id { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; } = true;

		public DataType()
		{
			IsActive = true;
		}
	}
}

