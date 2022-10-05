using System;
using System.ComponentModel.DataAnnotations.Schema;
using Lithium.BaseEntities;

namespace Lithium.Configuration.Core.Elements;

/// <summary>
/// Contract Type Attribute
/// </summary>
public record Attribute : BaseEntity<string>
{
    [ForeignKey(name: nameof(DataType))]
    public string DataTypeId { get; set; }

    public string HelpContent { get; set; }

    public bool IsGlobal { get; set; } = true;
    public bool IsMandatory { get; set; } = false;
    public bool IsForeign { get; set; } = false;
    public bool IsSearchable { get; set; } = false;

    public virtual DataType DataType { get; }

    public virtual IEnumerable<ContractTypeAttribute> ContractTypeAttributes { get; set; }

    public Attribute()
    {
    }
}

