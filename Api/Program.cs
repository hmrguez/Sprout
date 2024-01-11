using System.Text.Json.Serialization;
using Api;
using Api.Controllers;
using Contracts.Authentication;

var builder = WebApplication.CreateSlimBuilder(args);

builder.AddJsonSerializers();

var app = builder.Build();

var authApi = app.MapGroup("/auth");
authApi.MapPost("/register", AuthenticationController.Register);
authApi.MapPost("/login", AuthenticationController.Login);


app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}