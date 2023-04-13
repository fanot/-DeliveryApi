using AutoMapper;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Dish;
using WebApi.Models.Order;
using System;
namespace WebApi.Services
{
    public interface IDishService
    {
        IEnumerable<Dish> GetAll();
        Dish GetDetails(string id);
        public bool CheckRating(string dishId, string userId);

        public void PostRating(int? rating, string userId, string dishId);
        public void Rating(string dishId);


       // public Task<List<DishPagedListDto>> GetList(DishCategory? categoryOrder, bool? vegetarian, DishSorting sortOrder = DishSorting.NameAsc, int page = 1);

        //  Task AddToCart(Guid userId, string dishId);

    }
    public class DishService : IDishService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        public DishService(
                DataContext context,
                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Dish> GetAll()
        {
            return _context.Dish;
        }

        public Dish GetDetails(string id)
        {

            var dish = getDeatails(id);

            return dish;

        }
       /* public async Task<List<DishPagedListDto>> GetList(DishCategory? categoryOrder, bool? vegetarian, DishSorting sortOrder = DishSorting.NameAsc, int page = 1)
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
             if (categoryOrder.HasValue)
             {
                 dishes = categoryOrder switch
                 {
                     DishCategory.Pizza => dishes.Where(s => s.Category.Equals(DishCategory.Pizza)),
                     DishCategory.Wok => dishes.Where(s => s.Category.Equals(DishCategory.Wok)),
                     DishCategory.Soup => dishes.Where(s => s.Category.Equals(DishCategory.Soup)),
                     DishCategory.Dessert => dishes.Where(s => s.Category.Equals(DishCategory.Dessert)),
                     DishCategory.Drink => dishes.Where(s => s.Category.Equals(DishCategory.Drink)),
                 };
             }
             if (vegetarian.HasValue)
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
             return viewModel;
         }
       /*  public async Task AddToFavorite(string userId, string dishId)
         {
             var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
             if (user == null)
             {
                 throw new KeyNotFoundException($"User with Id = {userId} does not found");
             }
             var dish = getDeatails(dishId);
             var cart = new Cart
             {
                 User = user,
                 Dish = dish
             };
             await _context.Cart.AddAsync(cart);
             user.Cart.Add(cart);
             await _context.SaveChangesAsync();
         }*/

        public bool CheckRating(string dishId, string userId)
        {
            bool True = true;
            var rating  = _context.RatingScore.FirstOrDefault(x => x.UserId == userId && x.DishId == dishId);
            if (rating == null)
            {
                var rating_dish = _context.Cart.FirstOrDefault(x => x.Dish.Id == dishId && x.Orders.Status == OrderStatus.Delivered);

                if (rating_dish != null)
                {
                    _context.RatingScore.Add(
                        new RatingScore
                        {
                            UserId = userId,
                            DishId = dishId
                        });
                    _context.SaveChanges();

                }
                else
                {
                    True = false;
                }
            }

            return True;

        }

        public void PostRating(int? rating, string userId, string dishId)
        {
           

          
                    var rating_dish_users =_context.RatingScore.FirstOrDefault(x => x.UserId == userId && x.DishId == dishId);
                    rating_dish_users.Rating = rating;
                    var dish = _context.Dish.FirstOrDefault(x => x.Id == dishId);

            /*dish.Rating = _context.RatingScore
                        .Where(x => x.DishId == dishId)
                        .Select(x => x.Rating).AverageAsync();*/
            // _context.Dish.Update(dish);
          //  Rating(dishId);
            // dish.Rating = rating_dish;
            _context.SaveChanges();
               
        }
        public void Rating(string dishId)
        {
            var dish = _context.Dish.FirstOrDefault(x => x.Id == dishId);

            var rating_dish =  _context.RatingScore
                        .Where(x => x.DishId == dishId)
                        .Select(x => x.Rating).Average();
            dish.Rating = rating_dish;
            // Save changes
            _context.SaveChanges();
        }

        // helper methods

        private Dish getDeatails(string id)
        {

            var dish = _context.Dish.Where(x => x.Id == id).FirstOrDefault();
            if (dish == null) throw new KeyNotFoundException("Dish not found");
            return dish;
        }
    }
}

