using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatusCode.Models;

namespace StatusCode.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private SistemaContext DbSistema = new SistemaContext();

        [HttpGet]
        public void RequererTodos()
        {

        }

        [HttpGet]
        public void RequererUmPelaId(int Id)
        {

        }

        [HttpPost]
        public void PublicarUm(Usuario Usuario)
        {
        
        }

        [HttpDelete]
        public void DeletarUmPelaId(int Id, Usuario Usuario)
        {

        }

        [HttpPut]
        public void SubstituirUmPelaId(int Id, Usuario Usuario)
        {

        }
    }
}
