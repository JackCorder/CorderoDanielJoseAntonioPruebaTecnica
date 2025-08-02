using CorderoDanielJoseAntonioPruebaTecnica.Models;
using CorderoDanielJoseAntonioPruebaTecnica.Services;
using Microsoft.Extensions.Options;
using Xunit;

namespace CorderoDanielJoseAntonioPruebaTecnica.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly IAuthService _authService;

        public AuthServiceTests()
        {
            var options = Options.Create(new JwtSettings
            {
                Key = "EstaEsUnaClaveSuperSecreta12345678", // Debe tener al menos 16 caracteres
                Issuer = "TestIssuer",
                Audience = "TestAudience",
                ExpirationMinutes = 60
            });

            _authService = new AuthService(options);
        }

        [Fact]
        public void Authenticate_ValidCredentials_ReturnsToken()
        {
            var token = _authService.Authenticate("antonio@gmail.com", "12345678");
            Assert.False(string.IsNullOrWhiteSpace(token));
        }

        [Fact]
        public void Authenticate_InvalidCredentials_ThrowsUnauthorizedAccessException()
        {
            Assert.Throws<UnauthorizedAccessException>(() =>
                _authService.Authenticate("otro@gmail.com", "wrongpass"));
        }
    }
}
