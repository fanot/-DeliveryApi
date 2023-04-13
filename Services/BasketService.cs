using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using X.PagedList;

namespace WebApi.Services
{
    public interface IBasketService
    {
        // public void AddItem(Entities.Dish dish, double quantity);
        public Task<List<DishBasketDTO>> GetCart(string userId);
        public Task AddToCart(string userId, string dishId);
        public Task DeleteFromCart(string userId, string dishId, bool? increase);

    }
    public class BasketService : IBasketService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        public BasketService(
                DataContext context,
                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DishBasketDTO>> GetCart(string userId)
        {
       
            
                return await _context.Cart
                .Include(x => x.Dish)
                .Where(x => x.Users.Id == userId && x.Orders == null)
                .Select(
                x => new DishBasketDTO
                {
                    Id = x.Dish.Id,
                    Name = x.Dish.Name,
                    Price = x.Dish.Price,
                    Image = x.Dish.Image,
                    Amount = x.Amount,
                    //TotalPrice = x.Dish.Price * x.Amount

                }).ToListAsync();
            
           
        }
        public async Task AddToCart(string userId, string dishId)

        {
            int amount = 1;
            // int totalPrice = 1;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id = {userId} does not found");
            }
            var dish = await Get(dishId);

            var basket = await _context.Cart
                .Include(x => x.Dish)
                .FirstOrDefaultAsync(x => x.Dish.Id == dishId && x.Orders == null);
        
            if (basket != null )

            {

              
                    basket.Amount += 1;
                    basket.TotalPrice = dish.Price * basket.Amount;

                
            }
            else
            {
                 
                    var cart = new Cart
                    {
                        Users = user,
                        Dish = dish,
                        Amount = amount,
                        TotalPrice = dish.Price,

                    };
                
                await _context.Cart.AddAsync(cart);
                user.Carts.Add(cart);
            }
            await _context.SaveChangesAsync();


        }
    
        public async Task DeleteFromCart(string userId, string dishId, bool? increase)

        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id = {userId} does not found");
            }
            var dish = await Get(dishId);
            var basket = await _context.Cart
                .Include(x => x.Dish)
                .FirstOrDefaultAsync(x => x.Dish.Id == dishId && x.Orders == null);
            if (basket == null)
            {
                throw new KeyNotFoundException($"Dish with id = {dishId} doesn't in basket");
            }
            if (increase == true)
            {
                basket.Amount -= 1;
                if (basket.Amount == 0)
                {
                    _context.Cart.Remove(basket);

                }
            }
            else
            {
                _context.Cart.Remove(basket);
                //basket.Remove(x => x.Dish.Id == dishId);

            }
            await _context.SaveChangesAsync();


        }
        private async Task<Dish> Get(string id)
        {
            var dish = await _context.Dish.FirstOrDefaultAsync(x => x.Id == id);
            if (dish == null)
            {
                throw new KeyNotFoundException($"Dish with Id={id} does not found!");
            }
            return dish;
        }

        /*  private List<CartLine> lineCollection = new List<CartLine>();

          public void AddItem(Entities.Dish dish, double quantity)
          {
              CartLine line = lineCollection
                  .Where(g => g.Dish.Id == dish.Id)
                  .FirstOrDefault();

              if (line == null)
              {
                  lineCollection.Add(new CartLine
                  {
                      Dish = dish,
                      Quantity = quantity
                  });
              }
              else
              {
                  line.Quantity += quantity;
              }
          }

          public void RemoveLine(Entities.Dish dish)
          {
              lineCollection.RemoveAll(l => l.Dish.Id == dish.Id);
          }

          public decimal ComputeTotalValue()
          {
              return (decimal)lineCollection.Sum(e => e.Dish.Price * e.Quantity);

          }
          public void Clear()
          {
              lineCollection.Clear();
          }




      }*/
    }
}
