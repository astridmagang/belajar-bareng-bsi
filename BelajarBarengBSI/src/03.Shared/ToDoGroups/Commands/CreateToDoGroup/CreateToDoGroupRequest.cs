using FluentValidation;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Constants;

namespace Zeta.BelajarBarengBSI.Shared.ToDoGroups.Commands.CreateToDoGroup;

public class CreateToDoGroupRequest
{
    public string Name { get; set; } = default!;
}

public class CreateToDoGroupRequestValidator : AbstractValidator<CreateToDoGroupRequest>
{
    public CreateToDoGroupRequestValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(MaximumLengthFor.Name);
    }
}
