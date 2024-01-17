using System.Text.Json.Serialization;

namespace Contracts.Authentication;

public record RegisterRequest(string Username, string Email, string Password);

