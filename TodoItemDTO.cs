namespace TodoApi;

public class TodoItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public TodoItemDTO() { }
    public TodoItemDTO(Todo todoitem) =>
    (Id, Name, IsComplete) = (todoitem.Id, todoitem.Name, todoitem.IsComplete);
}
