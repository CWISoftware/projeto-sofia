using System;

namespace Sofia.SharedKernel.Events
{
    public interface IDomainEvent
    {
        DateTime Date { get; }
    }
}
