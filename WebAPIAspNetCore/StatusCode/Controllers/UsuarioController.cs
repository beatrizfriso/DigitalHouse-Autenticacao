using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatusCode.Models;
using StatusCode.Services;

namespace StatusCode.Controllers
{
    [Route("Api/[controller]")]
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
            var usuario = DbSistema.Usuarios.Where(usuario => usuario.Username == credencial.Username && usuario.Senha == credencial.Senha).FirstOrDefault();


            if (usuario == null)
            {
                return NotFound(new { menseger = "Usuário ou senha incorretos." });
            }
            else
            {
                var token = TokenService.GerarChaveToken();
                return new { token = token, id = usuario.Id, nome = usuario.Nome, sobrenome = usuario.Sobrenome, username = usuario.Username };
            }
        }

        [HttpGet]
        [Route("Usuarios")]
        [Authorize]
        public ActionResult<Usuario> ListarUsuarios()
        {
            return Ok(DbSistema.Usuarios.ToList());
        }
    }
}
