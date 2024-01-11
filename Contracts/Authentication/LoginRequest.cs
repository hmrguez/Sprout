using System.Text.Json.Serialization;

namespace Contracts.Authentication;

public record LoginRequest(string Email, string Password);

[JsonSerializable(typeof(LoginRequest[]))]
public partial class LoginRequestSerializerContext : JsonSerializerContext
{
}