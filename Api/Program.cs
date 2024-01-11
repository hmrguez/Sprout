using Api;
using Api.Controllers;
using Application;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.AddJsonSerializers();
    builder.Services.AddApplication();
}

var app = builder.Build();

var authApi = app.MapGroup("/auth");
{
    authApi.MapPost("/register", AuthenticationController.Register);
    authApi.MapPost("/login", AuthenticationController.Login);
}

app.Run();