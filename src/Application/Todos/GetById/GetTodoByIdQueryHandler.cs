using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.GetById;

public sealed class GetTodoByIdQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetTodoByIdQuery, TodoResponse>
{
    public async Task<Result<TodoResponse>> Handle(
        GetTodoByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        TodoResponse? todo = await context
            .TodoItems.Where(todoItem => todoItem.Id == query.TodoItemId)
            .Select(todoItem => new TodoResponse
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete,
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (todo is null)
        {
            return Result.Failure<TodoResponse>(TodoItemErrors.NotFound(query.TodoItemId));
        }

        return todo;
    }
}
