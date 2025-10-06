using Application.Abstractions.Messaging;
using Application.Todos.Complete;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Todos;

internal sealed class Complete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "todos/{id:int}/complete",
                async (
                    int id,
                    ICommandHandler<CompleteTodoCommand> handler,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new CompleteTodoCommand(id);

                    Result result = await handler.Handle(command, cancellationToken);

                    return result.Match(Results.NoContent, CustomResults.Problem);
                }
            )
            .WithTags(Tags.Todos);
    }
}
