﻿namespace br.com.deveficiente.mercadolivre.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IMediator mediator,
                               ILogger<LoginController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("/CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCreateResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Result<UserCreateResponse>> CreateUser([FromBody] UserCreateRequest userCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return new Result<UserCreateResponse>
                {
                    Succeeded = false,
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                };
            }
            var userSaveCommand = userCreateRequest.RequestToCommand(userCreateRequest);
            var command = await _mediator.Send(userSaveCommand);

            return new Result<UserCreateResponse>
            {
                Succeeded = true,
                Data = command.Data
            };
        }
    }
}