using System.Text.Json.Serialization;

namespace Contracts.Authentication;

public record LoginRequest(string Username, string Password);

