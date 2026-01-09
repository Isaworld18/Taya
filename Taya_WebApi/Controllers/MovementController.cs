namespace Taya_WebApi.Controllers
{
    using System.Net;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Taya_Api.Response;
    using Taya_Application.Commands;
    using Taya_Application.Querys;
    using Taya_Helper;
    using Taya_Helper.DTOs;
    using Taya_Helper.Filters;

    /// <summary>
    /// Movement main controller including CRUD endpoints
    /// </summary>
    [ApiController]
    [Route("api/Movements")]
    public class MovementController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        /// <summary>
        /// Main constructor por DI
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public MovementController(IMediator mediator, ILogger logger)
        { 
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get a single movement by his Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{movementId}")]
        [ProducesResponseType(typeof(MovementDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBy([FromRoute] Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetByIdMovementQuery(id));

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on GetBy method, {ex.Message}", DateTime.UtcNow.ToLongTimeString());

                return BadRequest("Unable to execute your action, please try again later");
            }
        }

        /// <summary>
        /// Get many movements by a filter parameter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByFilter")]
        [ProducesResponseType(typeof(GetMovementResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBy([FromBody] MovementFilter filter)
        {
            try
            {
                var data = await _mediator.Send(new GetByFiltersMovementQuery(filter));

                var totals = MovementHelper.GetTotalAmounts(data);

                GetMovementResponse response = new()
                { 
                    Data = data,
                    TotalMovement = data.Count(),
                    TotalIncomes = totals.Value,
                    TotalExpenses = totals.Key
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on GetBy method, {ex.Message}", DateTime.UtcNow.ToLongTimeString());

                return BadRequest("Unable to execute your action, please try again later");
            }
        }

        /// <summary>
        /// Get all existing movements on the system
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(GetMovementResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromBody] BaseFilter filter)
        {
            try
            {
                var data = await _mediator.Send(new GetAllMovementQuery(filter));

                var totals = MovementHelper.GetTotalAmounts(data);

                GetMovementResponse response = new()
                {
                    Data = data,
                    TotalMovement = data.Count(),
                    TotalIncomes = totals.Value,
                    TotalExpenses = totals.Key
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on GetBy method, {ex.Message}", DateTime.UtcNow.ToLongTimeString());

                return BadRequest("Unable to execute your action, please try again later");
            }
        }

        /// <summary>
        /// Add a new movement
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Guid?), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Add([FromBody] MovementDto data)
        {
            try
            {
                Guid? result = await _mediator.Send(new AddMovementCommand(data));

                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on Add method, {ex.Message}", DateTime.UtcNow.ToLongTimeString());

                return BadRequest("Unable to execute your action, please try again later");
            }
        }
    }
}
