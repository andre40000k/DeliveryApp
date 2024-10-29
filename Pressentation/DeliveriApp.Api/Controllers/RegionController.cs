using DeliveriApp.Application.Contract.Requests;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : CommonController<RegionController>
    {
        public RegionController(ILogger<RegionController> logger) : base(logger) { }

        [HttpPost("AddRegion")]
        public async Task<IActionResult> AddRegion([FromServices] IRequestHendler<UpsertRegionCommand> regionCommand,
            [FromBody] RequestRegion requestRegionCommand)
        {
            Logger.LogInformation("Add region with name {RegionName} ", requestRegionCommand.RegionName);

            try
            {
                await regionCommand.HendlerAsync(new UpsertRegionCommand
                {
                    CityId = requestRegionCommand.CityId,
                    RegionName = requestRegionCommand.RegionName,
                    MinDistanceFromCafe = requestRegionCommand.MinDistanceFromCafe,
                    MaxDistanceFromCafe = requestRegionCommand.MaxDistanceFromCafe
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Has been gotten error during crated region. Error: {Message}", requestRegionCommand);
            }

            Logger.LogInformation("Has been add region with name {RegionName} ", requestRegionCommand.RegionName);

            return Ok(200);
        }

        [HttpPost("AddRengeRegion")]
        public async Task<IActionResult> AddRengeRegion([FromServices] IRequestHendler<UpsertRegionCommand> regionCommand,
            int countRegion, Guid CityId)
        {
            Logger.LogInformation("Craeat {countRegion} regions", countRegion);

            if (countRegion < 1)
            {
                Logger.LogWarning("Has been entered {countRegion} this count of regions less then 1", countRegion);
                return BadRequest("404");
            }

            int maxRegionInOneCircke = 6;
            int baseWidthRegion = 2000;
            int currentRegion = 1;
            int countOfCircle = (int)Math.Ceiling((double)countRegion / maxRegionInOneCircke);

            for (int i = 0; i < countOfCircle; ++i)
            {
                int maxDistance = (i + 1) * baseWidthRegion;
                int minDistance = maxDistance - baseWidthRegion + 1;
                int leftRegion = Math.Abs(countRegion - i * maxRegionInOneCircke);

                int countRegionInCircle = leftRegion > maxRegionInOneCircke ? maxRegionInOneCircke : leftRegion;

                for (int j = 0; j < countRegionInCircle; j++)
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

            Logger.LogInformation("Has been craeated {countRegion} regions", countRegion);
            return Ok(200);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRegion([FromServices] IRequestHendler<DelIfExistsIdCommand> requestHendler,
           [FromBody] RequestId requestIdCommand)
        {
            Logger.LogInformation("Remove the region by id {Id}", requestIdCommand.Id);

            try
            {
                await requestHendler.HendlerAsync(new DelIfExistsIdCommand
                {
                    Id = requestIdCommand.Id
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Has been not delited region by Id. Error: {Message}", requestIdCommand.Id);
            }

            Logger.LogInformation("Has been removed the region by id {Id}", requestIdCommand.Id);

            return Ok(200);
        }
    }
}

