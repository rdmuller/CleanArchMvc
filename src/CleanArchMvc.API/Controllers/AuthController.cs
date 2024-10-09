using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [Route("LoginUser")]
    [ProducesResponseType(typeof(UserTokenDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromServices] IAuthenticate useCase,
        [FromServices] IAccessTokenGenerator accessTokenGenerator,
        [FromBody] LoginModelDTO userInfo
        )
    {
        var isAuthenticate = await useCase.Authenticate(userInfo.Email, userInfo.Password);

        if (!isAuthenticate)
        {
            ModelState.AddModelError(string.Empty, "Invalid logn");
            return Unauthorized(ModelState);
        }

        var user = new User()
        {
            Email = userInfo.Email,
        };

        var result = new 
        {
            jwtToken = accessTokenGenerator.GenerateAccessToken(user)
        };

        return Ok(result);
    }
}