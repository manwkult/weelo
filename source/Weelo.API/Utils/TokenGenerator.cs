namespace Weelo.API.Utils
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Weelo.Domain.Models;

  internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(User user, string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}