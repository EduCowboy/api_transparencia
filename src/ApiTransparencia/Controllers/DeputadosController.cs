using ApiTransparencia.Domain.Interfaces;
using ApiTransparencia.Domain.Models.Deputados;
using Microsoft.AspNetCore.Mvc;

namespace ApiTransparencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeputadosController : ControllerBase
    {

        private readonly IDeputadosService _deputadosService;

        public DeputadosController(IDeputadosService deputadosService)
        {
            _deputadosService = deputadosService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetListaDeputados([FromQuery] ListaDeputadosRequestModel request)
        {
            try
            {
                var deputados = await _deputadosService.ObterListaDeputadosAsync(request);
                return Ok(deputados);
            }
            catch (Exception ex)
            {
                // Aqui você pode tratar o erro de acordo com a sua necessidade
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("detalhes/{Id}")]
        public async Task<IActionResult> GetDetalhesDeputado([FromRoute] DetalhesDeputadosRequestModel request)
        {
            try
            {
                var deputado = await _deputadosService.ObterDetalhesDeputadoAsync(request);
                return Ok(deputado);
            }
            catch (Exception ex)
            {
                // Aqui você pode tratar o erro de acordo com a sua necessidade
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }   
        }

        [HttpGet("despesas/{Id}")]
        public async Task<IActionResult> GetDespesasDeputado([FromRoute] DetalhesDeputadosRequestModel request)
        {
            try
            {
                var deputado = await _deputadosService.ObterDetalhesDeputadoAsync(request);
                return Ok(deputado);
            }
            catch (Exception ex)
            {
                // Aqui você pode tratar o erro de acordo com a sua necessidade
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }   
        }
    }
}
