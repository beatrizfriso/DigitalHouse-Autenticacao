using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StatusCode.Services
{
    public static class TokenService
    {
        public static string GerarChaveToken()
        {
            var jwt = new JwtSecurityTokenHandler();

            var payload = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Ambiente.Chave)),
                    SecurityAlgorithms.HmacSha256)
            };

            var chaveToken = jwt.CreateToken(payload);

            return jwt.WriteToken(chaveToken);
        }
    }
}