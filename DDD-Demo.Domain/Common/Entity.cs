using MediatR;

namespace Core.Domain.Common

{
    public abstract class Entity
    {
        public List<INotification> DomainEvents { get; } = new();
        public void ClearDomainEvents() => DomainEvents.Clear();
    }
}
