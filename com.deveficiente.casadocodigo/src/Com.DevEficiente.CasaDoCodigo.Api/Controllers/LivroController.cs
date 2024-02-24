using Com.DevEficiente.CasaDoCodigo.Aplication.Mappers;

namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LivroController> _logger;
        private  readonly LivroMapper _livroMapper ;
        public LivroController(IMediator mediator, ILogger<LivroController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _livroMapper = new LivroMapper();
        }

        [HttpPost("/CriarLivro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroResponse))]
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
                var autorSaveCommand = _livroMapper.RequestToCommand(livroRequest);
                var command = await _mediator.Send(autorSaveCommand);
                return Ok(command);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Um Livro  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Um Livro");
            }
        }
    }
}
