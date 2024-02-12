namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(IMediator mediator, ILogger<CategoriaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("/CriarCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarCategoria([FromBody] CategoriaRequest categoriaRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var autorSaveCommand = categoriaRequest.RequestToCommand(categoriaRequest);
                var command = await _mediator.Send(autorSaveCommand);
                return Ok(command);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Uma Categoria  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Uma Categoria");
            }
        }
    }
}
