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
        public async Task<IActionResult> GetFiltredOrders([FromServices] IRsponsHendler<ResponsFirstThityMinutesOrders> response)
        {
            var orders = await response.HendlerAsync();

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }

        [HttpGet("FiltrationOrdersUseRegionId")]
        public async Task<IActionResult> GetFiltredOrdersByRegionId(Guid requestId, 
            [FromServices] IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders> response)
        {
            var orders = await response.HendlerAsync(new GetByIdRegionQuery
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
