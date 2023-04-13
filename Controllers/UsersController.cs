namespace WebApi.Controllers;

using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using NuGet.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;



[Authorize]
[ApiController]
[Route("api/account")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;
    private IJwtUtils _jwtUtils;
    private DataContext _context;

    public UsersController(
        DataContext context,
        IUserService userService,
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IJwtUtils jwtUtils)
    {
        _context = context;
        _userService = userService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
        _jwtUtils = jwtUtils;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Authenticate(LoginCredentials model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(UserRegisterModel model)
    {
        var now = DateTime.Now;

       /* if ( !Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
        {
            ModelState.AddModelError(nameof(model.Email),"Email address must be in a valid format");
            return BadRequest(ModelState);
        }*/
        if (model.BirthDate>now)
        {
            ModelState.AddModelError(nameof(model.BirthDate), "Birth date can't be later than today");
            return BadRequest(ModelState);
        }
        if (!Regex.IsMatch(model.Password, @"^(?=.*\d)(?=.*[a-z]).*$"))
        {
            ModelState.AddModelError(nameof(model.Password), "Password requires at least one digit");
            return BadRequest(ModelState);
        }
       
        if (!Regex.IsMatch(model.PhoneNumber, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"))
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), "The field PhoneNumber is invalid.");
            return BadRequest(ModelState);
        }
        else if (ModelState.IsValid) 
        {

            var response = _userService.Register(model);
            return Ok(response);

        }
        else
        {
            return BadRequest(ModelState);
        }
        
    }
    [Authorize]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var user = _context.Users.SingleOrDefault(x => x.Token == token);
        if (user == null)
            return Forbid();
        var u = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var response = _userService.Logout(u);

        return Ok(new { message = "Logged out" });        
       
    }
    /*[Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }*/
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {

        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var user_token = _context.Users.SingleOrDefault(x => x.Token == token);
        if (user_token == null)
            return Forbid();
        var u = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var user = _userService.GetProfile(u);
        
        return Ok(user);
       
    }
    [Authorize]
    [HttpPut("update")]
    

    public IActionResult Update(UserEditModel model)
    {
        var now = DateTime.Now;

        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var user = _context.Users.SingleOrDefault(x => x.Token == token);
        if (user == null)
            return Forbid();
        if (model.BirthDate > now)
        {
            ModelState.AddModelError(nameof(model.BirthDate), "Birth date can't be later than today");
            return BadRequest(ModelState);
        }
        if (!Regex.IsMatch(model.PhoneNumber, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"))
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), "The field PhoneNumber is invalid.");
            return BadRequest(ModelState);
        }
        
      
        else if (ModelState.IsValid)
        {
            var u = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _userService.Update(u, model);
            return Ok(new { message = "User updated successfully" });
        }
        else
        {
            return BadRequest();

        }
}
    /*
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }*/

}