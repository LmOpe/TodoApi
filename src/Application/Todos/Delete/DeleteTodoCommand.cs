using Application.Abstractions.Messaging;

namespace Application.Todos.Delete;

public sealed record DeleteTodoCommand(int TodoItemId) : ICommand;
