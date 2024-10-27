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
        [HttpPost("AddRegion")]
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

        [HttpPost("AddRengeRegion")]
        public async Task<IActionResult> AddRengeRegion([FromServices] IRequestHendler<UpsertRegionCommand> regionCommand,
            int countRegion, Guid CityId)
        {
            if(countRegion < 12) 
            {
                return BadRequest(404);
            }

            int baseWidthRegion = 2000;
            int currentRegion = 1;
            int countOfCircle = countRegion / 6;

            for (int i = 1; i < countOfCircle + 1; ++i)
            {
                int maxDistance = i * baseWidthRegion;
                int minDistance = maxDistance - baseWidthRegion + 1;

                for (int j = 0; j < 6; j++)
                {                    
                    await regionCommand.HendlerAsync(new UpsertRegionCommand
                    {
                        CityId = CityId,
                        RegionName = $"R{currentRegion}",
                        MinDistanceFromCafe = minDistance,
                        MaxDistanceFromCafe = maxDistance
                    });
                    ++currentRegion;
                }    
            }
            

            return Ok(200);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRegion([FromServices] IRequestHendler<DelIfExistsIdCommand> requestHendler,
           [FromBody] RequestIdCommand requestIdCommand)
        {
            await requestHendler.HendlerAsync(new DelIfExistsIdCommand
            {
                Id = requestIdCommand.Id
            });

            return Ok(200);
        }
    }
}

