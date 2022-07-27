using B2C.Api.Services;
using B2C.Api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace B2C.Api.Controllers;

[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("get-user-info")]
    public async Task<ActionResult> GetPromoCode([FromBody] UserRequest userRequest)
    {
        var user = await _userService.GetByEmail(userRequest.Email);
        return Ok(new { phoneNumber = user.PhoneNumber, tShopId = user.TShopId });
    }

    [HttpGet("get-all")]
    public Task<ActionResult> GetUsers()
    {
        return Task.FromResult<ActionResult>(Ok(new { users = _userService.GetAll() }));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] UserRequest userRequest)
    {
        await _userService.Create(userRequest.Email);
        return Ok(new { users = _userService.GetAll() });
    }
}