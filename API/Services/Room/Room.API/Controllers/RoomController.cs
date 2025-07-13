

using System.Net;
using MediatR;
using Room.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Room.Application.Responses;
using Room.Application.Queries;

namespace Room.API.Controllers
{
    public class RoomController(IMediator mediator, ILogger<RoomController> logger) : ApiController
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<RoomController> _logger = logger;

        [HttpPost("CreateNewRoom", Name = "CreateNewRoom")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> CreateNewRoom([FromBody] CreateRoomCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("List", Name = "GetUserRooms")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<RoomResponse>>> GetRoomsByUserName([FromQuery] string userName, int PageIndex = 1, int PageSize = 10) 
        {
            var query = new GetRoomsByUsernameQuery(userName, PageIndex, PageSize);
            var userRooms = await _mediator.Send(query);
            return Ok(userRooms);
        }
    }
}
