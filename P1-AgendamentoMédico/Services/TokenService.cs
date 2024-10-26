using Microsoft.IdentityModel.Tokens;
using P1_AgendamentoMédico.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace P1_AgendamentoMédico.Services
{
    public class TokenService
    {
            private readonly IConfiguration _configuration;

            public TokenService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string CreateCustomerToken(Paciente paciente)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SECRET_KEY"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, paciente.Nome),
                    new Claim(ClaimTypes.Email, paciente.Email),
                    new Claim("id", paciente.Id.ToString()),
                        // new Claim(ClaimTypes.Role, usuario.Perfil.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
        }
    }
