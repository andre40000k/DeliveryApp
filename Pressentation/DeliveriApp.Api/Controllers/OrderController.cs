using DeliveriApp.Application.Contract.Requests;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromServices] IRequestHendler<UpsertOrderCommand> requestHendler,
            [FromBody] RequestOrderCommand orderCommand)
        {
            await requestHendler.HendlerAsync(new UpsertOrderCommand
            {
                RegionId = orderCommand.RegionId,
                OrderWeight = orderCommand.OrderWeight,
                TimeOrder = orderCommand.TimeOrder,
                Distance = orderCommand.Distance,
                DeliveriTime = orderCommand.DeliveriTime
            });

            return Ok(200);
        }

        [HttpPost("AddRangeOrders")]
        public async Task<IActionResult> AddRangeOrders([FromServices] IRequestHendler<UpsertManyOrdersCommand> requestHendler,
            [FromBody] RequestManyOrdersCommand orderCommand)
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
