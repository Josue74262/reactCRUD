using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reactCRUD.Server.Models;

namespace reactCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly testReactContext _testReactContext;

        public UsuarioController(testReactContext context) 
        {
            _testReactContext = context;    
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Usuario> lista = await _testReactContext.Usuarios.OrderByDescending(u => u.IdUser).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Usuario request)
        {
            await _testReactContext.Usuarios.AddAsync(request);
            await _testReactContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Usuario request)
        {
            _testReactContext.Usuarios.Update(request);
            await _testReactContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Usuario usuario = _testReactContext.Usuarios.Find(id);
            _testReactContext.Usuarios.Remove(usuario);
            await _testReactContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
