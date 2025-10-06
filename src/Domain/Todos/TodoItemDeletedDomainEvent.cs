using SharedKernel;

namespace TodoApi.src.Domain.Todos;

public sealed record TodoItemDeletedDomainEvent(int TodoItemId) : IDomainEvent;
