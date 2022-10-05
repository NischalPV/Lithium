using System.ComponentModel.DataAnnotations.Schema;
using Lithium.BaseEntities;

namespace Lithium.Configuration.Core.Elements
{
	/// <summary>
    /// Contract type model
    /// </summary>
    public record ContractType: BaseEntity<string>
	{
		public int Version { get; protected set; }
		public string InstanceId { get; private set; }

		[ForeignKey(name: nameof(Category))]
		public string CategoryId { get; set; }

		[ForeignKey(name: nameof(Feature))]
		public string FeatureId { get; set; }
		public bool IsLatest { get; private set; }
		public bool IsPublished { get; private set; }
		public DateTime? PublishedDate { get; private set; }
		public string PublishedBy { get; private set; }

		public ContractCategory Category { get; }
		public Feature Feature { get; }

		public virtual IEnumerable<ContractTypeAttribute> ContractTypeAttributes { get; set; }

		public ContractType(int version, string instanceId)
		{
			Id = Guid.NewGuid().ToString();
			Version = version;
			InstanceId = instanceId;
			IsLatest = true;
			IsPublished = false;
		}

		public void MarkAsPublished(string publishedBy)
        {
			IsPublished = true;
			PublishedDate = DateTime.UtcNow;
			PublishedBy = publishedBy;
        }

		public void MarkAsStale()
        {
			IsLatest = false;
        }
	}
}

