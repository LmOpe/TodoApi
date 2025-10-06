using SharedKernel;

namespace Domain.Todos;

public sealed record TodoItemCompletedDomainEvent(int TodoItemId) : IDomainEvent;
