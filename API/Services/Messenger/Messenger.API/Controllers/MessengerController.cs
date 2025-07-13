using System.Net;
using MediatR;
using Messenger.Application.Commands;
using Messenger.Application.Queries;
using Messenger.Application.Responses;
using Messenger.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    public class MessengerController(IMediator mediator, ILogger<MessengerController> logger) : ApiController
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<MessengerController> _logger = logger;

        [HttpPost(Name = "CreateNewChat")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateNewChat([FromBody] CreateChatCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{userId}", Name = "GetUserChats")]
        [ProducesResponseType(typeof(IEnumerable<ChatResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ChatResponse>>> GetUserChats(Guid userId) 
        {
            var query = new GetChatsByUserIdQuery(userId);
            var userChats = await _mediator.Send(query);
            return Ok(userChats);
        }

        [HttpGet("messages/{chatId}", Name = "GetChatMessages")]
        [ProducesResponseType(typeof(PaginatedList<MessageResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedList<MessageResponse>>> GetChatMessages(Guid chatId, int pageIndex = 1, int pageSize = 50) 
        {
            var query = new GetChatMessagesByChatIdQuery(chatId, pageIndex, pageSize);
            var chatMessages = await _mediator.Send(query);
            return Ok(chatMessages);
        }

        [HttpPost("messages", Name = "CreateChatMessage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateChatMessage([FromBody] CreateMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
