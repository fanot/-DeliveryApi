namespace WebApi.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Dish;
using WebApi.Services;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DishController : ControllerBase
{
    private IBasketService _basketService;
    private IDishService _dishService;
    private DataContext _context;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public DishController(
        IBasketService basketService,
        IDishService dishService,
        IMapper mapper,
        DataContext context,
        IOptions<AppSettings> appSettings)
    {
        _basketService = basketService;
        _dishService = dishService;
        _mapper = mapper;
        _context = context;
        _appSettings = appSettings.Value;

    }


    [AllowAnonymous]
    [HttpGet("dish")]
    public async Task<IActionResult> GetList(DishCategory? categoryFilter, bool? vegetarian, DishSorting sortOrder = DishSorting.NameAsc, int page = 1)
    {
        try
        {


            int pageSize = 5;

            var dishes = _context.Dish.AsQueryable();
            dishes = sortOrder switch
            {
                DishSorting.NameDesc => dishes.OrderByDescending(s => s.Name),
                DishSorting.PriceAsc => dishes.OrderBy(s => s.Price),
                DishSorting.PriceDesc => dishes.OrderByDescending(s => s.Price),
                DishSorting.RatingAsc => dishes.OrderBy(s => s.Rating),
                DishSorting.RatingDesc => dishes.OrderByDescending(s => s.Rating),
                _ => dishes.OrderBy(s => s.Name),
            };
            if (categoryFilter.HasValue)
            {
                dishes = categoryFilter switch
                {
                    DishCategory.Pizza => dishes.Where(s => s.Category.Equals(DishCategory.Pizza)),
                    DishCategory.Wok => dishes.Where(s => s.Category.Equals(DishCategory.Wok)),
                    DishCategory.Soup => dishes.Where(s => s.Category.Equals(DishCategory.Soup)),
                    DishCategory.Dessert => dishes.Where(s => s.Category.Equals(DishCategory.Dessert)),
                    DishCategory.Drink => dishes.Where(s => s.Category.Equals(DishCategory.Drink)),
                };
            }
            if (vegetarian == true)
            {
                dishes = dishes.Where(p => p.Vegetarian == vegetarian.Value);
            }

            var result = await dishes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            var count = await dishes.CountAsync();
            PageInfoModel pageViewModel = new PageInfoModel(count, page, pageSize);
            DishPagedListDto viewModel = new DishPagedListDto(result, pageViewModel);
            return Ok(viewModel);
        }
        catch
        {
            return BadRequest();
        }
    }

    [AllowAnonymous]
    [HttpGet("details/{id}")]
    public IActionResult GetDetails(string id)
    {
        try {
          
         var dish = _dishService.GetDetails(id);
        if (dish == null) return NotFound();

        return Ok(dish);
        }
        catch
        {
            return BadRequest();
        }

    }
    [HttpGet("check/{dishId}/rating")]
    public IActionResult CheckRating(string dishId)
    {
        try
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = _context.Users.SingleOrDefault(x => x.Token == token);
            if (user == null)
                return Forbid();

            return Ok(_dishService.CheckRating(dishId, User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        catch 
        {
            return BadRequest(false);
        }   
    }
    [HttpPost("check/{dishId}/rating")]
    public async Task<IActionResult> PostRating(int? rating,string dishId)
    {
        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var user = _context.Users.SingleOrDefault(x => x.Token == token);
        if (user == null)
            return Forbid();
        var dish = _context.Dish.Where(x => x.Id == dishId).FirstOrDefault();
        if (dish == null) throw new KeyNotFoundException($"Dish with id {dishId} does not found");
        var checking = _dishService.CheckRating(dishId, User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (checking == false)
            return BadRequest(new { message = "You can not set rating on dish that was not ordered" });
        else if (rating.HasValue)
        {
            if (0 <= rating && rating <= 10)
            {
               _dishService.PostRating(rating, User.FindFirstValue(ClaimTypes.NameIdentifier), dishId);
                _dishService.Rating(dishId);
                return Ok();
            }
            else return BadRequest(new { message = "Rating must be between 0 an 10" });
        }
       
        else
        {
            return Ok();
        }
  
     }
        
    
    /*[HttpPost("basket/{id}")]
    public async Task<IActionResult> AddToCart(string id)
    {
        try
        {
            await _basketService.AddToCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpGet]

    public async Task<IActionResult> GetCart()
    {
        try
        {
            return Ok(await _basketService.GetCart(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpDelete("basket/{id}")]

    public async Task<IActionResult> DeleteFrom(string id, bool? increase)
    {
        try
        {
            await _basketService.DeleteFromCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id, increase);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }

    }*/
}


