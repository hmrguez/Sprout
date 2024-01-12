using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string username, string email)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Secret)),
            SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, username),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
         var securityToken = new JwtSecurityToken(
             issuer: jwtSettings.Value.Issuer,
             audience: jwtSettings.Value.Audience,
             claims: claims,
             expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.Value.ExpiryMinutes),
             signingCredentials: signingCredentials
         );

         return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}