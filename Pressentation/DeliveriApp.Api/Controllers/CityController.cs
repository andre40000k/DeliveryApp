﻿using DeliveriApp.Application.Contract.Requests;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCity([FromServices] IRequestHendler<UpsertCityCommand> requestHendler,
            [FromBody] RequestCityCommand requesrCityCommand)
        {
            await requestHendler.HendlerAsync(new UpsertCityCommand
            {
                CityName = requesrCityCommand.CityName
            });

            return Ok(200);
        }
    }
}
