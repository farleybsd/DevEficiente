namespace br.com.deveficiente.mercadolivre.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMediator mediator,
                               ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("/CreateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryCreateResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Result<CategoryCreateResponse>> CreateUser([FromBody] CategoryCreateRequest userCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return new Result<CategoryCreateResponse>
                {
                    Succeeded = false,
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                };
            }
            var categorySaveCommand = userCreateRequest.RequestToCommand(userCreateRequest);
            var command = await _mediator.Send(categorySaveCommand);

            return new Result<CategoryCreateResponse>
            {
                Succeeded = true,
                Data = command.Data
            };
        }
    }
}