using System.ComponentModel.DataAnnotations;

namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CupomController> _logger;

        public CupomController(IMediator mediator, ILogger<CupomController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/Cupom")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CupomResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cupom([FromBody] CupomRequest cupomRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var cupomSaveCommand = cupomRequest.RequestToCommand(cupomRequest);
                var command = await _mediator.Send(cupomSaveCommand);
                return Ok(command);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Erro ao Salvar Um Cupom: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Um Cupom  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Um Cupom");
            }
        }
    }
}