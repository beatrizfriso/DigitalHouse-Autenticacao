using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatusCode.Models;
using StatusCode.Services;

namespace StatusCode.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private SistemaContext DbSistema = new SistemaContext();

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult<Usuario> Cadastrar(Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            DbSistema.Usuarios.Add(usuario);
            DbSistema.SaveChanges();
            return Ok(usuario);
        }

        [HttpPost]
        [Route("autenticar")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar(Credencial credencial)
        {
            var usuario = DbSistema.Usuarios.Where(Usuario => Usuario.Username == credencial.Username && Usuario.Senha == credencial.Senha).FirstOrDefault();


            if (usuario == null)
            {
                return NotFound(new { menseger = "Usuário ou senha incorretos." });
            }
            else
            {
                var token = TokenService.GerarChaveToken(usuario);
                return new { token = token, id = usuario.Id, nome = usuario.Nome, sobrenome = usuario.Sobrenome, username = usuario.Username };
            }
        }
        [HttpGet]
        [Route("Usuarios")]
        [Authorize]
        public ActionResult<Usuario> UsuariosCadastrados()
        {
            return Ok(DbSistema.Usuarios.ToList());
        }
    }
}
