using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Todos;

namespace Application.Todos.Create;

public class CreateTodoCommandHandler(IApplicationDbContext context)
    : ICommandHandler<CreateTodoCommand, int>
{
    public async Task<Result<int>> Handle(
        CreateTodoCommand command,
        CancellationToken cancellationToken
    )
    {
        var todoItem = new TodoItem { Name = command.Name, IsComplete = false };

        todoItem.Raise(new TodoItemCreatedDomainEvent(todoItem.Id));

        context.TodoItems.Add(todoItem);

        await context.SaveChangesAsync(cancellationToken);

        return todoItem.Id;
    }
}
