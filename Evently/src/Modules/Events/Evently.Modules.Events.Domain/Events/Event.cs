using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events;

public sealed class Event : Entity
{
    private Event()
    {
    }

    public Guid Id { get; private set; }
    public string Title {  get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public DateTime StartsAtUts { get; private set; }
    public DateTime? EndsAtUts { get; private set; }
    public EventStatus Status { get; private set; }

    public static Event Create(
        string title,
        string description,
        string location,
        DateTime startsAtUts,
        DateTime? endsAtUts)
    {
        var @event = new Event()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = location,
            StartsAtUts = startsAtUts,
            EndsAtUts = endsAtUts
        };

        @event.Raise(new EventCreatedDomainEvent(@event.Id));

        return @event;
    }
}
