using System.Text.Json.Serialization;

namespace Application.Authentication.Common;

public record AuthenticationResult(
    Guid Id,
    string Username,
    string Email,
    string Token);

[JsonSerializable(typeof(AuthenticationResult[]))]
public partial class AuthenticationResultSerializerContext : JsonSerializerContext
{
}

