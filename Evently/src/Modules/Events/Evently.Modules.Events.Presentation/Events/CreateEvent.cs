﻿using Evently.Modules.Events.Application.Events.CreateEvent;
using Evently.Modules.Events.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

internal static class CreateEvent
{
    public static void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async(Request request, ISender sender) =>
        {
            var command = new CreateEventCommand(
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUts,
                request.EndsAtUts);

            Guid eventId = await sender.Send(command);

            return Results.Ok(eventId);
        })
        .WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartsAtUts { get; set; }
        public DateTime? EndsAtUts { get; set; }
    }
}
