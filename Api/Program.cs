using Api;
using Api.Controllers;
using Api.Middleware;
using Application;
using Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Services.AddControllers();
    
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.MapControllers();
}

app.Run();