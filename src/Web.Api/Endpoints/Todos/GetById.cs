using Application.Abstractions.Messaging;
using Application.Todos.GetById;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Todos;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "todos/{id:int}",
                async (
                    int id,
                    IQueryHandler<GetTodoByIdQuery, TodoResponse> handler,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new GetTodoByIdQuery(id);

                    Result<TodoResponse> result = await handler.Handle(command, cancellationToken);

                    return result.Match(Results.Ok, CustomResults.Problem);
                }
            )
            .WithTags(Tags.Todos);
    }
}
