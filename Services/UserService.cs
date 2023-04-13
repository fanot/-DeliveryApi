namespace WebApi.Services;

using AutoMapper;
using Azure;
using Azure.Core;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;

public interface IUserService
{
    TokenResponse Authenticate(LoginCredentials model);
    //public UserDto Logout();
    IEnumerable<Users> GetAll();
    TokenResponse Register(UserRegisterModel model);
    public TokenResponse Logout(string id);
    void Update(string id, UserEditModel model);
    Users GetProfile(string id);

}

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;


    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public TokenResponse Authenticate(LoginCredentials model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Email or password is incorrect");

        // authentication successful
        var response = _mapper.Map<TokenResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        user.Token = response.Token;
        _mapper.Map<TokenResponse>(user);
        _context.Users.Update(user);
        _context.SaveChanges();


        return response;
    }
    public TokenResponse Logout(string id)
    {
        var user = getUser(id);
        // validate
        // if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
        // throw new AppException("Email or password is incorrect");

        // authentication successful
        var response = _mapper.Map<TokenResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        user.Token = response.Token;
        _mapper.Map<TokenResponse>(user);
        _context.Users.Update(user);
        _context.SaveChanges();


        return response;
    }
    public IEnumerable<Users> GetAll()
    {
        return _context.Users;
    }
    /* public UserDto Logout(HttpContext context)
     {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
         var userId = _jwtUtils.ValidateToken(token);
         if (user == null) throw new KeyNotFoundException("User not found");
         return user;
     }*/
    /*public Users GetById(int id)
    {
        return getUser(id);
    }*/

    public TokenResponse Register(UserRegisterModel model)
    {
        // validate
        if (_context.Users.Any(x => x.Email == model.Email))
            throw new AppException("Email '" + model.Email + "' is already taken");
        /*else if (_context.Users.Any(x => x.Gender != "Female" || x.Gender != "Male"))
            throw new AppException("Gender must be Female or Male");*/
        // map model to new user object
        var user = _mapper.Map<Users>(model);

        // hash password
        user.PasswordHash = BCrypt.HashPassword(model.Password);


        _context.Users.Update(user);

        var response = _mapper.Map<TokenResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        user.Token = response.Token;
        _context.SaveChanges();

        return response;
    }

    public void Update(string id, UserEditModel model)
    {
        var user = getUser(id);
        
        // validate
       /*if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
            throw new AppException("Email '" + model.Email + "' is already taken");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = BCrypt.HashPassword(model.Password);*/

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }
    public Users GetProfile(string id)
    {

        var user = getUser(id);

        return user;

    }
    

    // helper methods

    private Users getUser(string id)
    {

        var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
   
}