namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FechamentoVendaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FechamentoVendaController> _logger;

        public FechamentoVendaController(IMediator mediator, ILogger<FechamentoVendaController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/Comprar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompraResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Comprar([FromBody] CompraRequest compraRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var CompraSaveCommand = compraRequest.RequestToCommand(compraRequest);
                var command = await _mediator.Send(CompraSaveCommand);
                return Ok(command);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Um Compra  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Um Compra");
            }
        }
    }
}