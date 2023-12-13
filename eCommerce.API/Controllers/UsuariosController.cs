using eCommerce.API.Repositories;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var listaUsuarios = _usuarioRepository.Get();
           
            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            if (usuario != null)
                return Ok(usuario);
            else
                return NotFound("Não encontrado");
        }

        [HttpPost]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Usuario usuario, int id)
        {
            _usuarioRepository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Delete(id);

            return Ok();
        }
    }
}
