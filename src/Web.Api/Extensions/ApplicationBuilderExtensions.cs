namespace Web.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.DocumentTitle = "TodoAPI";
            config.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI v1");
            config.RoutePrefix = "swagger";
            config.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        });

        return app;
    }
}
