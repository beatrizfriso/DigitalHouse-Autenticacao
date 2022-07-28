using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StatusCode.Models;

namespace StatusCode.Services
{
    public class TokenService
    {
        public static string GerarChaveToken(Usuario usuario)
        {
            var token = new JwtSecurityTokenHandler();           
            var verifySignature = Encoding.ASCII.GetBytes(Ambiente.Chave);
            var payload = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Senha)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(verifySignature),
                    SecurityAlgorithms.HmacSha256
                    )
            };
            var chave = token.CreateToken(payload);
            return token.WriteToken(chave);
        }










    }
}
