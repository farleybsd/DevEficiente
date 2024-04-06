using Com.DevEficiente.CasaDoCodigo.Aplication.Mappers;
using Com.DevEficiente.CasaDoCodigo.Aplication.Result;

namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LivroController> _logger;
        private readonly LivroMapper _livroMapper;

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

        [HttpGet("/Buscar-Livros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroByIdQueryResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AutorResponse>> BuscarLivros([FromQuery] LivroByIdRequest LivroRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(LivroRequest.Id))
                    return BadRequest();

                var queryAutor = await _mediator.Send(LivroRequest.RequestToCommand(LivroRequest));
                return Ok(queryAutor);
            }
            catch (AutorByIdQueryException ex)
            {
                _logger.LogError($"Erro Ao Buscar Livro: {ex.Message}");
                throw new Exception("Erro Ao Buscar Livro:");
            }
        }
        [HttpGet("/DetalheLivros-Site")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhesDoLivroSiteResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DetalhesDoLivroSiteResponse>> DetalheLivrosSite([FromQuery] DetalhesDoLivroSiteRequest detalhesDoLivroSiteRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(detalhesDoLivroSiteRequest.Id))
                    return BadRequest();

                var queryAutor = await _mediator.Send(detalhesDoLivroSiteRequest.RequestToCommand(detalhesDoLivroSiteRequest));
                return Ok(queryAutor);
            }
            catch (AutorByIdQueryException ex)
            {
                _logger.LogError($"Erro Ao Buscar Livro: {ex.Message}");
                throw new Exception("Erro Ao Buscar Livro:");
            }
        }
    }
}