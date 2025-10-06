using Application.Abstractions.Messaging;

namespace Application.Todos.Get;

public sealed record GetTodosQuery() : IQuery<List<TodoResponse>>;
