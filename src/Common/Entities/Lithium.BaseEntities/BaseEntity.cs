using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text;
using MediatR;

namespace Lithium.BaseEntities;

public record IBaseEntity
{

    protected List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();


    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

}

public abstract record BaseEntity<T> : IBaseEntity
{
    int? _requestedHashCode;
    T _Id;
    string _uniqueIdentifier;

    public virtual T Id { get { return _Id; } protected set { _Id = value; } }
    public string Name { get; set; }
    public string Description { get; set; }

    public string UniqueIdentifier
    {
        get
        {
            _uniqueIdentifier = $"LI{CleanName()}";
            return _uniqueIdentifier;
        }
        private set { _uniqueIdentifier = value; }
    }

    public DateTime CreatedDate { get; protected set; }
    public DateTime? ModifiedDate { get; protected set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }

    [ForeignKey(name: nameof(Status))]
    public int StatusId { get; set; }

    [ForeignKey(name: nameof(LastStatus))]
    public int LastStatusId { get; set; }
    public string StatusChangedBy { get; set; }
    public DateTime? StatusChangedDate { get; set; }
    public bool IsActive { get; set; }


    public virtual Status Status { get; set; }
    public virtual Status LastStatus { get; set; }

    public bool IsTransient()
    {
        return EqualityComparer<T>.Default.Equals(this.Id, default(T));
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }

    protected string CleanName()
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in this.Name)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
            {
                sb.Append(c);
            }
        }
        string cleanName = sb.ToString();
        return cleanName;
    }

    public BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
        IsActive = true;
        StatusId = 1;
    }

    public BaseEntity(string createdBy)
    {
        CreatedBy = createdBy;
        CreatedDate = DateTime.UtcNow;
        IsActive = true;
        StatusId = 1;

    }

    public void UpdateStatus(int statusId, string statusChangedBy)
    {
        LastStatusId = this.StatusId;
        StatusId = statusId;
        StatusChangedBy = statusChangedBy;
        StatusChangedDate = DateTime.UtcNow;
    }

    public void Terminate(string terminatedBy)
    {
        LastStatusId = this.StatusId;
        StatusId = 8;
        StatusChangedBy = terminatedBy;
        StatusChangedDate = DateTime.UtcNow;
    }
}



