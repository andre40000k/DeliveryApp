using DeliveriApp.Application.Contract.Requests;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : CommonController<CityController>
    {
        public CityController(ILogger<CityController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromServices] IRequestHendler<UpsertCityCommand> requestHendler,
            [FromBody] RequestCity requesrCityCommand)
        {
            Logger.LogInformation("Has been add the city with name {RegionName} ", requesrCityCommand.CityName);

            await requestHendler.HendlerAsync(new UpsertCityCommand
            {
                CityName = requesrCityCommand.CityName
            });
            Logger.LogInformation("Has been add the city with name {RegionName} ", requesrCityCommand.CityName);
            return Ok(200);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCity([FromServices] IRequestHendler<DelIfExistsIdCommand> requestHendler,
            [FromBody] RequestId requestIdCommand)
        {
            Logger.LogInformation("Remove the city by id {Id}", requestIdCommand.Id);

            await requestHendler.HendlerAsync(new DelIfExistsIdCommand
            {
                Id = requestIdCommand.Id
            });

            Logger.LogInformation("Has been removed the city by id {Id}", requestIdCommand.Id);

            return Ok(200);
        }
    }
}
