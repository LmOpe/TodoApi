using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Get;

internal sealed class GetTodosQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetTodosQuery, List<TodoResponse>>
{
    public async Task<Result<List<TodoResponse>>> Handle(
        GetTodosQuery query,
        CancellationToken cancellationToken
    )
    {
        List<TodoResponse> todos = await context
            .TodoItems.Select(todoItem => new TodoResponse
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete,
            })
            .ToListAsync(cancellationToken);

        return todos;
    }
}
