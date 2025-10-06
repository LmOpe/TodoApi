using Application.Todos.Create;
using FluentValidation;

namespace TodoApi.src.Application.Todos.Create;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(255);
    }
}
