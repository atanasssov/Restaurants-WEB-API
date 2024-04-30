using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using Restaurants.Domain.Constants;
using Restaurants.Application.Users.Commands.UpdateUserDetails;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Application.Users.Commands.UnassignUserRole;

using MediatR;



namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/identity")]  
    public class IdentityController (IMediator mediator) : ControllerBase
    {
        // Update user details
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        // Posto to asign a role to an user
        [HttpPost("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        // Delete to unasign a user from a role
        [HttpDelete("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }


}
