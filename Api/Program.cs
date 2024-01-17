using Api;
using Api.Controllers;
using Api.Middleware;
using Application;
using Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.AddJsonSerializers();
    builder.Services.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
}

var authApi = app.MapGroup("/auth");
{
    authApi.MapPost("/register", AuthenticationController.Register);
    authApi.MapPost("/login", AuthenticationController.Login);
}

app.Run();