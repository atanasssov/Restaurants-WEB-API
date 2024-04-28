﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using Restaurants.Application.Users.Commands;

using MediatR;


namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/identity")]  
    public class IdentityController (IMediator mediator) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
