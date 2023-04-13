using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Order;
using WebApi.Models.Users;

namespace WebApi.Services
{
    public interface IOrderService
    {
        public Task FromBasket(OrderCreateDto model, string userId);
        public IEnumerable<Order> GetAll(string userId);
        public Task ConfirmDelivery(string orderId, string userId);
        public Task<OrderDto> Order(string orderId, string userId);
    }
    public class OrderService : IOrderService
    {
        private IBasketService _basketService;
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;


        public OrderService(
            IBasketService basketService,
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _basketService = basketService;
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }


        public IEnumerable<Order> GetAll(string userId)
        {
            return _context.Order
                .Where(x => x.Users.Id == userId);
        }
        public async Task ConfirmDelivery(string orderId, string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id = {userId} does not found");
            }
            var order = await _context.Order.FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with Id = {orderId} does not found");
            }
            if (order.Status == OrderStatus.Delivered)
            {
                throw new AppException($"Can't update status for order with id {orderId} ");
            }
            else
            {
                order.Status = OrderStatus.Delivered;


            }
            await _context.SaveChangesAsync();

            
        }

        public async Task FromBasket(OrderCreateDto model, string userId)
        {
            // List<DishDTO> lstCart = (List<DishDTO>);
            double? total = 0;
            var now = DateTime.Now;
            // validate
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id = {userId} does not found");
            }
            if (model.DeliveryTime <= now.AddMinutes(60))
                throw new AppException("Invalid delivery time. Delivery time must be more than current datetime on 60 minutes");
            var basket = await _context.Cart
                .FirstOrDefaultAsync(x => x.Users.Id == userId && x.Orders == null);

            if (basket == null)
            {
                throw new KeyNotFoundException($"Empty basket for user with Id= {userId}");
            }
            var price = _context.Cart
                .Include(c => c.Users)
                .Where(x => x.Users.Id == userId && x.Orders == null)
                .ToList();
            foreach (Cart ol in price)
            {
                total += ol.TotalPrice;
            }

            var order = new Order
            {

                Users = user,
                Amount = basket.Amount,
                Address = model.Address,
                OrderTime = DateTime.Now,
                DeliveryTime = model.DeliveryTime,
                Status = OrderStatus.InProcess,
                Price = total

                //   TotalPrice = dish.Price,

            };

            await _context.Order.AddAsync(order);
            user.Orders.Add(order);
            foreach (Cart ol in price)
            {
                ol.Orders = order;
            }
            await _context.SaveChangesAsync();


        }

        private void EmptyCart(string userId)
        {
            var cartItems = _context.Cart
                .Where(x => x.Users.Id == userId);

            foreach (var cartItem in cartItems)
            {
                _context.Cart.Remove(cartItem);
            }
            // Save changes
            _context.SaveChanges();
        }

        public async Task <OrderDto> Order(string orderId, string userId)
        {
            var order = await _context.Order.FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with Id = {orderId} does not found");
            }
            var basket = await _context.Cart
                 .Include(x => x.Orders)
                 .Where(x => x.Orders.Id == orderId && x.Users.Id == userId)
                 .Select(
                 x => new DishBasketDTO
                 {
                     Id = x.Dish.Id,
                     Name = x.Dish.Name,
                     Price = x.Dish.Price,
                     Image = x.Dish.Image,
                     Amount = x.Amount,
                     

                 }
                 ).ToListAsync();
            return new OrderDto
            {
                Id = order.Id,
                OrderTime = order.OrderTime,
                DeliveryTime = (DateTime)order.DeliveryTime,
                Status = order.Status,
                Address = order.Address,
                Price = order.Price,
                Basket = basket
            };


        }
    }

}
/*var oder_1 = await _context.Order
               .Include(x => x.Carts)
               .Where(x => x.Carts.Users.Id == userId)
               .Select(
               x => new Order
               {
                   Price = (double)x.Carts.TotalPrice,
                   Address = model.Address,
                   OrderTime = DateTime.Now,
                   DeliveryTime = model.DeliveryTime,
                   Status = OrderStatus.InProcess,

               }).ToListAsync();*/
