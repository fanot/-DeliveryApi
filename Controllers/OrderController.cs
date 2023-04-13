using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Order;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private DataContext _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private IDishService _dishService;


        public OrderController(
            IOrderService orderService,
            IDishService dishService,

            IMapper mapper,
            DataContext context,
            IOptions<AppSettings> appSettings)
        {
            _orderService = orderService;
            _dishService = dishService;
            _mapper = mapper;
            _context = context;
            _appSettings = appSettings.Value;

        }
        [HttpGet("order")]
        public IActionResult GetAll()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = _context.Users.SingleOrDefault(x => x.Token == token);
            if (user == null)
                return Forbid();
            var orders = _orderService.GetAll(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(orders);
        }
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder(OrderCreateDto model)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = _context.Users.SingleOrDefault(x => x.Token == token);
            if (user == null)
                return Forbid();
            await _orderService.FromBasket(model, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok();
            
           
        }
        [HttpPost("order/{id}/status")]
        public async Task<IActionResult> ConfirmDelivery(string id)
        {
            
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = _context.Users.SingleOrDefault(x => x.Token == token);
            if (user == null)
                return Forbid();
            await _orderService.ConfirmDelivery(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok();
            
           


    }
        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderDetails(string id)
        {
           
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = _context.Users.SingleOrDefault(x => x.Token == token);
            if (user == null)
                return Forbid();
            return Ok(await _orderService.Order(id, User.FindFirstValue(ClaimTypes.NameIdentifier)));
            
            
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


