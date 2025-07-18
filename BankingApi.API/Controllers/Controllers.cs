using BankingApi.Application.Services;
using BankingApi.Core.Interfaces;
//using BankingApi.Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    // Eliminado el campo privado redundante
    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
    {
        try
        {
            var token = await authService.Login(loginDTO);
            return Ok(token);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService accountService;

    public AccountsController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    // Eliminado el campo privado redundante
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDTO>>> Get()
    {
        try
        {
            var accounts = await accountService.GetAccounts();
            return Ok(accounts);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}