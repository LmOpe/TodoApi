using SharedKernel;

namespace Domain.Todos;

public class TodoItemErrors
{
    public static Error AlreadyCompleted(int todoItemId) =>
        Error.Problem(
            "TodoItems.AlreadyCompleted",
            $"The todo items with Id = '{todoItemId}' is already completed."
        );

    public static Error NotFound(int todoItemId) =>
        Error.Notfound(
            "TodoItems.NotFound",
            $"The to-do item with the Id = '{todoItemId}' was not found."
        );
}
