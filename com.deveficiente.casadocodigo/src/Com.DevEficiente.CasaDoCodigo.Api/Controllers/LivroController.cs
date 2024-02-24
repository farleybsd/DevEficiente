using Com.DevEficiente.CasaDoCodigo.Aplication.Request;

namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LivroController> _logger;
        public LivroController(IMediator mediator, ILogger<LivroController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("/CriarLivro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarLivro([FromBody] LivroCreateRequest livroRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Uma Categoria  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Uma Categoria");
            }
            return Ok();
        }
    }
}
