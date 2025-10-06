using SharedKernel;

namespace TodoApi.src.Domain.Todos;

public sealed record TodoItemUpdatedDomainEvent(int TodoItemId) : IDomainEvent;
