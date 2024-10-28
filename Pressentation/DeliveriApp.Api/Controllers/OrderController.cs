using DeliveriApp.Application.Contract.Requests;
using DeliveriApp.Application.Contract.Respons;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Application.UpsertModels.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("FiltrationOrders")]
        public async Task<IActionResult> GetFirstThirtyMinutesOrders(Guid requestId, 
            [FromServices] IRequestHendler<GetByIdQuery, ResponsFirstThityMinutesOrders> response)
        {
            var orders = await response.HendlerAsync(new GetByIdQuery
            {
                Id = requestId
            });

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }


        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromServices] IRequestHendler<UpsertOrderCommand> requestHendler,
            [FromBody] RequestOrder order)
        {
            await requestHendler.HendlerAsync(new UpsertOrderCommand
            {
                RegionId = order.RegionId,
                OrderWeight = order.OrderWeight,
                TimeOrder = order.TimeOrder,
                Distance = order.Distance,
                DeliveriTime = order.DeliveriTime
            });

            return Ok(200);
        }

        [HttpPost("AddRangeOrders")]
        public async Task<IActionResult> AddRangeOrders([FromServices] IRequestHendler<UpsertManyOrdersCommand> requestHendler,
            [FromBody] RequestManyOrders orderCommand)
        {
            await requestHendler.HendlerAsync(new UpsertManyOrdersCommand
            {
                Id = orderCommand.Id,
                countOrders = orderCommand.countOrders
            });

            return Ok(200);
        }
    }
}
