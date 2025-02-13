using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MRS.Identity.API.Models;

namespace MRS.Identity.API.Controllers;

[Route("api/identity")]
public class AuthController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    
    [HttpPost("register")]
    public async Task<ActionResult> Register(UserRegister userRegister)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = new IdentityUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            EmailConfirmed = true
        };
        
        var result = await _userManager.CreateAsync(user, userRegister.Password);

        if (!result.Succeeded) return BadRequest();
        
        await _signInManager.SignInAsync(user, false);
        return Ok();
    }
    
    [HttpPost("authenticate")]
    public async Task<ActionResult> Login(UserLogin userLogin)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, false);
        
        if (!result.Succeeded) return BadRequest();
        
        return Ok();
    }
}