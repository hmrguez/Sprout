using System.Text.Json.Serialization;

namespace Contracts.Authentication;

public record AuthenticationResponse(Guid Id, string FirstName, string LastName, string Email, string Token);

[JsonSerializable(typeof(AuthenticationResponse[]))]
public partial class AuthenticationResponseSerializerContext : JsonSerializerContext
{
}

