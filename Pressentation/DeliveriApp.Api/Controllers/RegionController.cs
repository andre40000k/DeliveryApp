using DeliveriApp.Application.Contract.Requests;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddRegion([FromServices] IRequestHendler<UpsertRegionCommand> regionCommand,
            [FromBody] RequestRegionCommand requesrRegionCommand)
        {
            await regionCommand.HendlerAsync(new UpsertRegionCommand
            {
                CityId = requesrRegionCommand.CityId,
                RegionName = requesrRegionCommand.RegionName,
                MinDistanceFromCafe = requesrRegionCommand.MinDistanceFromCafe,
                MaxDistanceFromCafe = requesrRegionCommand.MaxDistanceFromCafe
            });

           return Ok(200);
        }
    }
}
