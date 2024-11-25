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
    public class OrderController : CommonController<OrderController>
    {
        public OrderController(ILogger<OrderController> logger) : base(logger) { }

        [HttpGet("FiltrationOrders")]
        public async Task<IActionResult> GetFiltredOrders([FromServices] IResponsHendler<ResponsFirstThityMinutesOrders> response)
        {
            var orders = await response.HendlerAsync();

            Logger.LogInformation("Get filtered orders {Count} ", orders.Orders.Count());

            if (orders == null)
            {
                Logger.LogWarning("No orders {Count} ", null);
                return NotFound();
            }

            Logger.LogInformation("Sent filtered orders {Count} ", orders.Orders.Count());
            return Ok(orders);
        }

        [HttpGet("FiltrationOrdersUseRegionId")]
        public async Task<IActionResult> GetFiltredOrdersByRegionId(Guid requestId, 
            [FromServices] IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders> response)
        {
            Logger.LogInformation("Get filtered orders by the region id {Id} ", requestId);
            var orders = await response.HendlerAsync(new GetByIdRegionQuery
            {
                Id = requestId
            });

            if (orders == null)
            {
                Logger.LogWarning("No orders {Count} ", null);
                return NotFound();
            }

            Logger.LogInformation("Sent filtered orders {Count} ", orders.Orders.Count());


            return Ok(orders);
        }


        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromServices] IRequestHendler<UpsertOrderCommand> requestHendler,
            [FromBody] RequestOrder order)
        {
            Logger.LogInformation("Get new order for the region {RegionId} ", order.RegionId);

            await requestHendler.HendlerAsync(new UpsertOrderCommand
            {
                RegionId = order.RegionId,
                OrderWeight = order.OrderWeight,
                TimeOrder = order.TimeOrder,
                Distance = order.Distance,
                DeliveriTime = order.DeliveriTime
            });

            Logger.LogInformation("The order added {order} ", order);

            return Ok(200);
        }

        [HttpPost("AddRangeOrders")]
        public async Task<IActionResult> AddRangeOrders([FromServices] IRequestHendler<UpsertManyOrdersCommand> requestHendler,
            [FromBody] RequestManyOrders orderCommand)
        {
            Logger.LogInformation("Add renge of orders {Count} ", orderCommand.countOrders);
            await requestHendler.HendlerAsync(new UpsertManyOrdersCommand
            {
                Id = orderCommand.Id,
                countOrders = orderCommand.countOrders
            });

            Logger.LogInformation("Saccessful has added {Count} of orders", orderCommand.countOrders);

            return Ok(200);
        }
    }
}
