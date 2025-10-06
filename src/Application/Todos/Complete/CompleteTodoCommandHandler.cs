using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Complete;

internal sealed class CompleteTodoCommandHandler(IApplicationDbContext context)
    : ICommandHandler<CompleteTodoCommand>
{
    public async Task<Result> Handle(
        CompleteTodoCommand command,
        CancellationToken cancellationToken
    )
    {
        TodoItem? todoItem = await context.TodoItems.SingleOrDefaultAsync(
            t => t.Id == command.TodoItemId,
            cancellationToken
        );

        if (todoItem is null)
        {
            return Result.Failure(TodoItemErrors.NotFound(command.TodoItemId));
        }

        if (todoItem.IsComplete)
        {
            return Result.Failure(TodoItemErrors.AlreadyCompleted(command.TodoItemId));
        }

        todoItem.IsComplete = true;
        todoItem.Raise(new TodoItemCompletedDomainEvent(todoItem.Id));

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
