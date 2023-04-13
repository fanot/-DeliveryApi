using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class BasketController : ControllerBase
    {
        private IBasketService _basketService;
        private DataContext _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private IDishService _dishService;


        public BasketController(
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
        [HttpPost("basket/{id}")]
        public async Task<IActionResult> AddToCart(string id)
        {
            try
            {
                var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var user = _context.Users.SingleOrDefault(x => x.Token == token);
                if (user == null)
                    return Forbid();
                await _basketService.AddToCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
                return Ok();
            }
            catch 
            { 
                return BadRequest();
            }
            
        }
        [HttpGet("basket")]

        public async Task<IActionResult> GetCart()
        {
            try
            {
                var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var user = _context.Users.SingleOrDefault(x => x.Token == token);
                if (user == null)
                    return Forbid();
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
                var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var user = _context.Users.SingleOrDefault(x => x.Token == token);
                if (user == null)
                    return Forbid();
                await _basketService.DeleteFromCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id, increase);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }


        /* // POST: BasketController/Create
         [HttpPost]
         public ActionResult Af(string id)
         {

             var dish1 = _dishService.GetDetails(id);
             // Организация - создание корзины
             Cart cart = new Cart();

             // Действие
             cart.AddItem(dish1, 1);

             List<CartLine> results = cart.Lines.OrderBy(c => c.Dish.Id).ToList();
             decimal result = cart.ComputeTotalValue();

             return Ok(results);
         }

         */
    }
}


