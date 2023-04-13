using System.Numerics;
using WebApi.Entities;
using X.PagedList;

namespace WebApi.Models.Dish
{
    public class PageInfoModel
    {
        public int Size { get; }
        public int Count { get; }
        public int Current { get; }
        
        public PageInfoModel(int count, int pageNumber, int pageSize)
        {
            Size = pageSize;
            Count = (int)Math.Ceiling(count / (double)pageSize);
            Current = pageNumber;
        }
    }
        public class DishPagedListDto
    {
        public IEnumerable<Entities.Dish> Dishes { get; }
        public PageInfoModel Pagination { get; }
        public DishPagedListDto(IEnumerable<Entities.Dish> dishes, PageInfoModel viewModel)
        {
            Dishes = dishes;
            Pagination = viewModel;
        }
       
    }
}
