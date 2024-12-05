using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Events.Api.Events;

public sealed class Event
{
    public Guid Id { get; set; }
    public string Title {  get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartsAtUts { get; set; }
    public DateTime? EndsAtUts { get; set; }
    public EventStatus Status { get; set; }
}
