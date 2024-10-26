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
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromServices] IRequestHendler<UpsertOrderCommand> requestHendler,
            [FromBody] RequestOrderCommand orderCommand)
        {
            await requestHendler.HendlerAsync(new UpsertOrderCommand
            {
                RegionId = orderCommand.RegionId,
                OrderWeight = orderCommand.OrderWeight,
                DeliveriTime = orderCommand.DeliveriTime
            });

            return Ok(200);
        }
    }
}
