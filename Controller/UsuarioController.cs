using CyaEnglish.Models;
using CyaEnglish.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CyaEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetById([FromRoute] Guid id)
        {
            UsuarioModel usuario = await _usuarioRepository.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("newUser")]
        public async Task<ActionResult<UsuarioModel>> SetNewUser([FromBody] UsuarioModel usuariowModel)
        {
            UsuarioModel usuario = new UsuarioModel(
                                                    usuariowModel.Name,
                                                    usuariowModel.Email,
                                                    usuariowModel.Password,
                                                    usuariowModel.SecretKey
                                                    ); 
                await _usuarioRepository.Insert(usuario);
            return Ok(usuario);
        }

        [HttpPut("updateUser")]
        public async Task<ActionResult<UsuarioModel>> SetUpdateUser([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel retorno = await _usuarioRepository.Update(usuarioModel);

            if (retorno == null)
                return Ok("Erro ao realizar atualização nos dados");
            return Ok("Dados atualizados com sucesso!");
        }
    }
}
