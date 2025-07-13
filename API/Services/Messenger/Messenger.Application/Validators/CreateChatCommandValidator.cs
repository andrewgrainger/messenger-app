using FluentValidation;
using Messenger.Application.Commands;

namespace Messenger.Application.Validators;

public class CreateChatCommandValidator : AbstractValidator<CreateChatCommand>
{
    public CreateChatCommandValidator()
    {
        /*RuleFor(x => x.UserIds)
            .NotEmpty()
            .Must(u => u.Count >= 2)
            .WithMessage("Must contain at least 2 users to start a chat.");*/
    }
}
