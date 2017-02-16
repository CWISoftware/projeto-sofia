using System;

namespace Core.Crosscutting.Events
{
    public interface IDomainEvent
    {
        DateTime Date { get; }
    }
}
