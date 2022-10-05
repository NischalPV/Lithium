using System;
using MediatR;

namespace Lithium.BaseEntities;

public record IBaseAppStaging
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

public abstract record BaseAppStaging<T>: IBaseAppStaging
{
    T _Id;

    int? _requestedHashCode;

    public virtual T Id { get { return _Id; } protected set { _Id = value; } }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; protected set; }
    public DateTime? ModifiedDate { get; protected set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsActive { get; set; }

    public BaseAppStaging()
    {
        CreatedDate = DateTime.UtcNow;
        IsActive = true;
    }

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
}

