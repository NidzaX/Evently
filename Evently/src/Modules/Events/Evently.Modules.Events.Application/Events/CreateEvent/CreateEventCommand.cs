using FluentValidation;
using MediatR;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUts,
    DateTime? EndsAtUts) : IRequest<Guid>;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.StartsAtUts).NotEmpty();
        RuleFor(c => c.EndsAtUts).Must((cmd, endsAtUtc) => endsAtUtc > cmd.StartsAtUts).When(c => c.EndsAtUts.HasValue);

    }
}
