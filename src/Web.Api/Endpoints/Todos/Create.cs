using Application.Abstractions.Messaging;
using Application.Todos.Create;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints;

public sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public required string Name { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "todos",
                async (
                    Request request,
                    ICommandHandler<CreateTodoCommand, int> handler,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new CreateTodoCommand { Name = request.Name };

                    Result<int> result = await handler.Handle(command, cancellationToken);

                    return result.Match(Results.Ok, CustomResults.Problem);
                }
            )
            .WithTags(Tags.Todos);
    }
}
