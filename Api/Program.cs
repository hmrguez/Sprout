using Api;
using Api.Controllers;
using Application;
using Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.AddJsonSerializers();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

var authApi = app.MapGroup("/auth");
{
    authApi.MapPost("/register", AuthenticationController.Register);
    authApi.MapPost("/login", AuthenticationController.Login);
}

app.Run();