using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Security.Claims;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly HttpContextAccessor httpContextAccessor;

        public OrderController(IMediator mediator, HttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            this.httpContextAccessor = httpContextAccessor;
        }
        public static string GetUsername(this ClaimsPrincipal user) 
            => user.FindFirst(ClaimTypes.GroupSid)?.Value;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersViewModel>>> GetOrders([FromQuery] string userName)
        {
            var query = new GetOrdersListQuery(userName);
            return await mediator.Send(query);

          var a =  httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.GroupSid)?.Value;


        }

    }
}
