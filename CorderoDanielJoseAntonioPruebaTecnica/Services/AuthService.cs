using CorderoDanielJoseAntonioPruebaTecnica.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CorderoDanielJoseAntonioPruebaTecnica.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        // Usuario de prueba
        private readonly string _hardcodedEmail = "antonio@gmail.com";
        private readonly string _hardcodedPassword = "12345678";

        public string Authenticate(string email, string password)
        {
            if (email != _hardcodedEmail || password != _hardcodedPassword)
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
