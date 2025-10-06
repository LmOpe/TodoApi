using SharedKernel;

namespace Domain.Todos;

public sealed record TodoItemCreatedDomainEvent(int TodoItemId) : IDomainEvent;
