using Application.Todos.Delete;
using FluentValidation;

namespace TodoApi.src.Application.Todos.Delete;

internal sealed class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
{
    public DeleteTodoCommandValidator()
    {
        RuleFor(c => c.TodoItemId).NotEmpty();
    }
}
